/*******************************************************************
 * FileName: UIButtonNormal.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIButtonNormal : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {
                private string m_soundName;
                private UnityAction m_action;
                private Image m_Image;
                public bool interactable {
                    get { return m_interactable; }
                    set {
                        m_interactable = value;
                        if (value) {
                            SetNormal();
                        } else {
                            SetDisable();
                        } // end if
                    } // end set
                } // end interactable
                private bool m_interactable;
                private static Material m_grapMat;
                private static Material grapMat {
                    get {
                        if (null == m_grapMat) {
                            m_grapMat = new Material(Shader.Find("UI/Gray"));
                        } // end if
                        return m_grapMat;
                    } // end if
                } // end grapMat

                private void SetNormal() {
                    if (null != m_Image) {
                        m_Image.raycastTarget = true;
                        m_Image.material = null;
                    } // end if
                } // end SetNormal

                private void SetPressed() {
                    if (null != m_Image) {
                        m_Image.material = grapMat;
                    } // end if
                } // end SetHighlight

                private void SetDisable() {
                    if (null != m_Image) {
                        m_Image.raycastTarget = false;
                        m_Image.material = grapMat;
                    } // end if
                } // end SetDisable

                protected override void Awake() {
                    interactable = true;
                    m_Image = GetComponent<Image>();
                } // end Awake

                public void AddListener(UnityAction _action, string _soundName = "ui_btn") {
                    m_action += _action;
                    m_soundName = _soundName;
                } // end AddListener

                public void RemoveListener(UnityAction _action) {
                    m_action -= _action;
                } // end RemoveListener

                public void RemoveAllListener() {
                    m_action = null;
                } // end RemoveAllListener

                public void OnPointerClick(PointerEventData eventData) {
                    if (null == m_action || false == m_interactable) return;
                    // end if
                    if (false == string.IsNullOrEmpty(m_soundName)) {
                        SceneManager.mainAudio.PlaySound(m_soundName);
                    } // end if
                    m_action();
                } // end OnPointerClick

                public void OnPointerDown(PointerEventData eventData) {
                    if (false == m_interactable) return;
                    // end if
                    SetPressed();
                } // end OnPointerDown

                public void OnPointerUp(PointerEventData eventData) {
                    if (false == m_interactable) return;
                    // end if
                    SetNormal();
                } // end OnPointerUp
            } // end class UIButton 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider