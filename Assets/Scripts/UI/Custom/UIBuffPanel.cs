/*******************************************************************
 * FileName: UIBuffPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Solider.Config.Icon;
using Framework.Manager;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIBuffPanel : IDisposable {
                #region /********** 图标 **********/
                private class Icon : IDisposable {
                    public string id { get; private set; }
                    private Image icon;
                    private Image mask;

                    public Icon(string id, RectTransform parent, Vector3 localPos, string spritePath, Vector2 iconSize) {
                        this.id = id;
                        icon = CanvasTool.InstantiateImage(id, parent, spritePath, localPos, iconSize);
                        mask = CanvasTool.InstantiateImage("mask", icon.rectTransform, Vector3.zero, iconSize);
                        mask.color = new Color(0, 0, 0, 0.33f);
                        mask.type = Image.Type.Filled;
                        mask.fillMethod = Image.FillMethod.Radial360;
                        mask.fillOrigin = 2;
                        mask.fillClockwise = false;
                        mask.fillAmount = 0;
                    } // end Icon

                    public void ResetIcon(string id, Vector3 localPos, string spritePath) {
                        this.id = id;
                        icon.rectTransform.localPosition = localPos;
                        icon.sprite = spritePath == null ? null : Resources.Load<Sprite>(spritePath);
                        mask.fillAmount = 0;
                        // end if
                    } // end ResetIcon

                    public void SetAmount(float amount) {
                        if (null == mask) return;
                        // end if
                        mask.fillAmount = amount;
                    } // end SetAmount

                    public void Dispose() {
                        if (null != mask) UnityEngine.Object.Destroy(mask.gameObject);
                        // end if
                        if(null != icon) UnityEngine.Object.Destroy(icon.gameObject);
                        // end if
                    } // end Dispose
                } // end class Icon
                #endregion
                private RectTransform parent;
                private Vector2 iconSize;
                private float interval;
                private List<Icon> iconList;

                public UIBuffPanel(RectTransform parent, Vector2 iconSize) {
                    this.parent = parent;
                    this.iconSize = iconSize;
                    interval = 2f;
                    iconList = new List<Icon>();
                    SceneManager.mainCharacter.center.AddListener(FreshenIcon);
                } // end UIBuffPanel

                public void Update() {
                    List<float> scheduleList = new List<float>();
                    if (null == scheduleList || scheduleList.Count > iconList.Count) {
                        FreshenIcon();
                        return;
                    } // end if
                    for (int i = 0; i < scheduleList.Count; i++) {
                        iconList[i].SetAmount(scheduleList[i]);
                    } // end for
                } // end Update

                private void FreshenIcon(Character.CenterEvent type) {
                    Debug.Log(type);
                    if (Character.CenterEvent.BuffChange != type) return;
                    // end if
                    FreshenIcon();
                } // end FreshenIcon

                private void FreshenIcon() {
                    List<BuffInfo> buffList  = new List<BuffInfo>();
                    if (null == buffList) {
                        for (int i = 0; i < iconList.Count; i++) {
                            iconList[i].Dispose();
                        } // end for
                        iconList.Clear();
                        return;
                    } // end if
                    Vector3 localPos = Vector3.zero;
                    for (int i = 0; i < buffList.Count; i++) {
                        BuffInfo info = buffList[i];
                        localPos = new Vector3((iconSize.x + interval) * (i % 5), (iconSize.y + interval) * (i / 5));
                        if (iconList.Count > i)
                            iconList[i].ResetIcon(info.id, localPos, info.spritepath);
                        else
                            iconList.Add(new Icon(info.id, parent, localPos, info.spritepath, iconSize));
                        // end if
                    } // end for
                    if (iconList.Count == buffList.Count) return;
                    // end if
                    for (int i = buffList.Count; i < iconList.Count; i++) {
                        iconList[i].Dispose();
                    } // end for
                    for (int i = buffList.Count; i < iconList.Count; i++) {
                        iconList.RemoveAt(i);
                    } // end for
                } // end UpdateShow

                public void Dispose() {
                    for (int i = 0; i < iconList.Count; i++) {
                        iconList[i].Dispose();
                    } // end for
                    iconList.Clear();
                    SceneManager.mainCharacter.center.RemoveListener(FreshenIcon);
                } // end Dispose
            } // end class UIBuffPanel 
        } // end namespace Custom
    } // end namespace UI
} // end namespace Custom