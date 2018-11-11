using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Framework {
    namespace Custom {
        namespace UI {
            /// <summary>
            /// 文本控件，支持超链接、图片
            /// </summary>
            [AddComponentMenu("UI/LinkImageText", 10)]
            public class LinkImageText : Text, IPointerClickHandler {
                /// <summary>
                /// 解析完最终的文本
                /// </summary>
                private string m_OutputText;
                /// <summary>
                /// 图片池
                /// </summary>
                protected readonly List<Image> m_ImagesPool = new List<Image>();
                /// <summary>
                /// 图片的最后一个顶点的索引
                /// </summary>
                private readonly List<int> m_ImagesVertexIndex = new List<int>();
                /// <summary>
                /// 超链接信息列表
                /// </summary>
                private readonly List<HrefInfo> m_HrefInfos = new List<HrefInfo>();
                /// <summary>
                /// 文本构造器
                /// </summary>
                protected static readonly StringBuilder s_TextBuilder = new StringBuilder();

                [Serializable]
                public class HrefClickEvent : UnityEvent<string> { } // end class HrefClickEvent
                [SerializeField]
                private HrefClickEvent m_OnHrefClick = new HrefClickEvent();

                /// <summary>
                /// 超链接点击事件
                /// </summary>
                public HrefClickEvent onHrefClick {
                    get { return m_OnHrefClick; } // end get
                    set { m_OnHrefClick = value; } // end set
                } // end onHrefClick

                /// <summary>
                /// 正则取出所需要的属性
                /// </summary>
                private static readonly Regex s_ImageRegex =
                    new Regex(@"<quad name=(.+?) size=(\d*\.?\d+%?) width=(\d*\.?\d+%?) />", RegexOptions.Singleline);
                /// <summary>
                /// 超链接正则
                /// </summary>
                private static readonly Regex s_HrefRegex =
                    new Regex(@"<a href=([^>\n\s]+)>(.*?)(</a>)", RegexOptions.Singleline);
                /// <summary>
                /// 加载精灵图片方法
                /// </summary>
                public static Func<string, Sprite> funLoadSprite;

                public override void SetVerticesDirty() {
                    base.SetVerticesDirty();
                    UpdateQuadImage();
                } // end SetVerticesDirty

                protected void UpdateQuadImage() {
#if UNITY_EDITOR
                    if (UnityEditor.PrefabUtility.GetPrefabType(this) == UnityEditor.PrefabType.Prefab) return;
                    // end if
#endif
                    m_OutputText = GetOutputText(text);
                    m_ImagesVertexIndex.Clear();
                    foreach (Match match in s_ImageRegex.Matches(m_OutputText)) {
                        int picIndex = match.Index;
                        int endIndex = picIndex * 4 + 3; // 猜测：每个字符需要4个顶点
                        m_ImagesVertexIndex.Add(endIndex);
                        m_ImagesPool.RemoveAll(image => image == null); // 移除 null 对象
                        if (m_ImagesPool.Count == 0) {
                            GetComponentsInChildren(m_ImagesPool);
                        } // end if
                        if (m_ImagesVertexIndex.Count > m_ImagesPool.Count) {
                            GameObject go = DefaultControls.CreateImage(new DefaultControls.Resources()); // 创建 Image 对象
                            go.layer = gameObject.layer;
                            RectTransform rt = go.transform as RectTransform;
                            if (null != rt) {
                                rt.SetParent(rectTransform);
                                rt.localPosition = Vector3.zero;
                                rt.localRotation = Quaternion.identity;
                                rt.localScale = Vector3.one;
                            } // end if
                            m_ImagesPool.Add(go.GetComponent<Image>());
                        } // end if
                        string spriteName = match.Groups[1].Value;
                        float size = float.Parse(match.Groups[2].Value);
                        Image img = m_ImagesPool[m_ImagesVertexIndex.Count - 1];
                        if (img.sprite == null || img.sprite.name != spriteName) {
                            img.sprite = funLoadSprite != null ? funLoadSprite(spriteName) :
                                Resources.Load<Sprite>(spriteName);
                        } // end if
                        img.rectTransform.sizeDelta = new Vector2(size, size);
                        img.enabled = true;
                    } // end foreach
                    for (int i = m_ImagesVertexIndex.Count; i < m_ImagesPool.Count; i++) { // 隐藏多余的图片
                        if (null != m_ImagesPool[i]) m_ImagesPool[i].enabled = false;
                        // end if
                    } // end for
                } // end UpdateQuadImage

                protected override void OnPopulateMesh(VertexHelper toFill) {
                    string orignText = m_Text;
                    m_Text = m_OutputText;
                    base.OnPopulateMesh(toFill);
                    m_Text = orignText;
                    UIVertex vert = new UIVertex();
                    for (int i = 0; i < m_ImagesVertexIndex.Count; i++) {
                        int endIndex = m_ImagesVertexIndex[i];
                        RectTransform rt = m_ImagesPool[i].rectTransform;
                        Vector2 size = rt.sizeDelta;
                        if (endIndex < toFill.currentVertCount) {
                            toFill.PopulateUIVertex(ref vert, endIndex); // 获取对应顶点的数据
                            rt.anchoredPosition = new Vector2(vert.position.x + size.x / 2, vert.position.y + size.y / 2);
                            // 抹掉左下角的小黑点
                            toFill.PopulateUIVertex(ref vert, endIndex - 3);
                            Vector3 pos = vert.position;
                            toFill.PopulateUIVertex(ref vert, endIndex);
                            vert.position = pos;
                            for (int j = endIndex, m = endIndex - 3; j > m; j--) {
                                toFill.SetUIVertex(vert, j);
                            } // end for
                        } // end if
                    } // end for
                    if (m_ImagesVertexIndex.Count != 0) {
                        m_ImagesVertexIndex.Clear();
                    } // end if
                      // 处理超链接包围框
                    foreach (var hrefInfo in m_HrefInfos) {
                        hrefInfo.boxes.Clear();
                        if (hrefInfo.startIndex >= toFill.currentVertCount) continue;
                        // end if
                        // 将超链接里面的文本顶点索引坐标加入到包围框
                        toFill.PopulateUIVertex(ref vert, hrefInfo.startIndex);
                        Vector3 pos = vert.position;
                        Bounds bounds = new Bounds(pos, Vector3.zero);
                        for (int i = hrefInfo.startIndex, m = hrefInfo.endIndex; i < m; i++) {
                            if (i >= toFill.currentVertCount) break;
                            // end if
                            toFill.PopulateUIVertex(ref vert, i);
                            pos = vert.position;
                            if (pos.x < bounds.min.x) { // 换行重新添加包围框
                                hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
                                bounds = new Bounds(pos, Vector3.zero);
                            } else {
                                bounds.Encapsulate(pos); // 扩展包围框
                            } // end if
                        } // end for
                        hrefInfo.boxes.Add(new Rect(bounds.min, bounds.size));
                    } // end foreach
                } // end OnPopulateMesh

                /// <summary>
                /// 获取超链接解析后的最后输出文本
                /// </summary>
                /// <returns></returns>
                protected virtual string GetOutputText(string outputText) {
                    s_TextBuilder.Length = 0;
                    m_HrefInfos.Clear();
                    int indexText = 0;
                    foreach (Match match in s_HrefRegex.Matches(outputText)) {
                        s_TextBuilder.Append(outputText.Substring(indexText, match.Index - indexText));
                        s_TextBuilder.Append("<color=blue>");  // 超链接颜色
                        HrefInfo hrefInfo = new HrefInfo {
                            startIndex = s_TextBuilder.Length * 4, // 超链接里的文本起始顶点索引
                            endIndex = (s_TextBuilder.Length + match.Groups[2].Length - 1) * 4 + 3,
                            name = match.Groups[1].Value
                        };
                        m_HrefInfos.Add(hrefInfo);
                        s_TextBuilder.Append(match.Groups[2].Value);
                        s_TextBuilder.Append("</color>");
                        indexText = match.Index + match.Length;
                    } // end foreach
                    s_TextBuilder.Append(outputText.Substring(indexText, outputText.Length - indexText));
                    return s_TextBuilder.ToString();
                } // end GetOutputText

                /// <summary>
                /// 点击事件检测是否点击到超链接文本
                /// </summary>
                /// <param name="eventData"></param>
                public void OnPointerClick(PointerEventData eventData) {
                    Vector2 lp;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        rectTransform, eventData.position, eventData.pressEventCamera, out lp);
                    foreach (var hrefInfo in m_HrefInfos) {
                        List<Rect> boxes = hrefInfo.boxes;
                        for (int i = 0; i < boxes.Count; ++i) {
                            if (boxes[i].Contains(lp)) {
                                m_OnHrefClick.Invoke(hrefInfo.name);
                                return;
                            } // end if
                        } // end for
                    } // end foreach
                } // end OnPointerClick

                /// <summary>
                /// 超链接信息类
                /// </summary>
                private class HrefInfo {
                    public int startIndex;
                    public int endIndex;
                    public string name;
                    public readonly List<Rect> boxes = new List<Rect>();
                } // end class HrefInfo
            } // end class LinkImageText 
        } // end namespace UI
    } // end namespace Custom
} // end namespace Framework