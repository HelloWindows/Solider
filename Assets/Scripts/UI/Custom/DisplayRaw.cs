/*******************************************************************
 * FileName: DisplayRaw.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Prefab;
using Framework.Tools;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class DisplayRaw : MonoBehaviour, IDragHandler, IBeginDragHandler {
                private float lastX;
                private Camera m_camera;
                private Vector3 rotSpeed;
                private GameObject displayGo;
                private bool disableDrag;
                private Vector3 localPos;
                private Vector3 localRot;
                private Vector3 localSca;

                public void OnBeginDrag(PointerEventData data) {

                    if (disableDrag) return;
                    // end if
                    lastX = data.position.x;
                } // end OnBeginDrag

                public void OnDrag(PointerEventData data) {

                    if (null == displayGo || disableDrag) return;
                    // end if
                    displayGo.transform.localEulerAngles -= rotSpeed * (data.position.x - lastX);
                    lastX = data.position.x;
                } // end OnDrag

                public void SwitchDrag(bool isOn) {
                    disableDrag = isOn;
                } // end DisableDrag

                public void SetFieldOfView(float value) {
                    m_camera.fieldOfView = 50;
                } // end SetFieldOfView

                public void ResetDisplayTrans(Vector3 localPos, Vector3 localRot, Vector3 localSca) {
                    this.localPos = localPos;
                    this.localRot = localRot;
                    this.localSca = localSca;
                } // end ResetDisplayTrans

                /// <summary>
                /// 清除展示物体
                /// </summary>
                public void ClearDiplay() {
                    if (null != displayGo) Destroy(displayGo);
                    // end if
                    displayGo = null;
                } // end ClearDiplay

                /// <summary>
                /// 替换展示物体
                /// </summary>
                /// <param name="go"> 待展示物体 </param>
                public void ReplaceDisplay(GameObject go) {
                    ReplaceDisplay(go, localPos, localRot, localSca);
                } // end ReplaceDisplay

                /// <summary>
                /// 替换展示物体
                /// </summary>
                /// <param name="go"> 待展示物体 </param>
                /// <param name="localPos"> 位置 </param>
                public void ReplaceDisplay(GameObject go, Vector3 localPos) {
                    ReplaceDisplay(go, localPos, localRot, localSca);
                } // end ReplaceDisplay

                /// <summary>
                /// 替换展示物体
                /// </summary>
                /// <param name="go"> 待展示物体 </param>
                /// <param name="localPos"> 位置 </param>
                /// <param name="localRot"> 角度 </param>
                /// <param name="localSca"> 比例 </param>
                public void ReplaceDisplay(GameObject go, Vector3 localPos, Vector3 localRot, Vector3 localSca) {
                    if (null != displayGo) Destroy(displayGo);
                    // end if
                    displayGo = null;
                    go.transform.SetParent(m_camera.transform);
                    go.transform.localScale = localSca;
                    go.transform.localPosition = localPos;
                    go.transform.localEulerAngles = localRot;
                    displayGo = go;
                } // end ReplaceDisplay

                public void ReplaceDisplayHero(string roleType, string weapon, string armor) {
                    if (null != displayGo) Destroy(displayGo);
                    // end if
                    displayGo = null;
                    displayGo = ObjectTool.InstantiateGo(roleType, Configs.prefabConfig.GetPath(roleType),
                        m_camera.transform, localPos, localRot, localSca);
                    foreach (Transform child in displayGo.transform) {
                        child.gameObject.layer = 2;
                    } // end foreach
                } // end ReplaceDisplayRole

                // Use this for initialization
                private void Awake() {
                    localPos = new Vector3(0, -7f, 20);
                    localRot = new Vector3(0, 180, 0);
                    localSca = Vector3.one * 15;
                    disableDrag = false;
                    rotSpeed = new Vector3(0, 1, 0);
                    RenderTexture texture = new RenderTexture(320, 420, 24, RenderTextureFormat.ARGB32);
                    texture.anisoLevel = 0;
                    texture.antiAliasing = 4;
                    texture.wrapMode = TextureWrapMode.Clamp;
                    texture.filterMode = FilterMode.Bilinear;
                    gameObject.GetComponent<RawImage>().texture = texture;

                    m_camera = ObjectTool.InstantiateEmptyGo("DisplayCamera", transform, new Vector3(0, 0, 1)).AddComponent<Camera>();
                    m_camera.clearFlags = CameraClearFlags.Color;
                    m_camera.backgroundColor = Color.gray;
                    m_camera.cullingMask = 1 << 2;
                    m_camera.fieldOfView = 50;
                    m_camera.targetTexture = texture;
                    m_camera.nearClipPlane = 0.1f;
                } // end Awake
            } // end class DisplayRaw 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider