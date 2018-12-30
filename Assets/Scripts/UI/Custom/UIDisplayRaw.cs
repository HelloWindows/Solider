/*******************************************************************
 * FileName: UIDisplayRaw.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.UI.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIDisplayRaw : UIBehaviour, IDragHandler, IBeginDragHandler {
                private float lastX;
                private Camera m_camera;
                private bool disableDrag;
                private IDisplayGo displayGo;

                public void OnBeginDrag(PointerEventData data) {
                    if (disableDrag) return;
                    // end if
                    lastX = data.position.x;
                } // end OnBeginDrag

                public void OnDrag(PointerEventData data) {
                    if (null == displayGo || disableDrag) return;
                    // end if
                    displayGo.Rotate(data.position.x - lastX);
                    lastX = data.position.x;
                } // end OnDrag

                public void SwitchDrag(bool isOn) {
                    disableDrag = isOn;
                } // end DisableDrag

                public void SetDisplayGo(IDisplayGo displayGo) {
                    if (null != this.displayGo) this.displayGo.Dispose();
                    // end if
                    this.displayGo = displayGo;
                    displayGo.Reset(m_camera.transform);
                } // end SetDisplayGo

                public void ClearDiplay() {
                    if (null != displayGo) displayGo.Dispose();
                } // end ClearDiplay

                public void FreshenDisplay() {
                    displayGo.Freshen();
                } // end Freshen

                // Use this for initialization
                protected override void Awake() {
                    disableDrag = false;
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
            } // end class UIDisplayRaw 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider