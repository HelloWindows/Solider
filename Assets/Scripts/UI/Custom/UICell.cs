/*******************************************************************
 * FileName: UICell.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;
using Framework.Tools;
using UnityEngine.EventSystems;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UICell : UIBehaviour, IPointerDownHandler, IPointerUpHandler {
                private Action pointerDownCall;
                public UIItem item { get; private set; }

                public void SetUIItem(Sprite sprite, int count) {
                    if (null == item) {
                        item = ObjectTool.InstantiateGo("ItemUI", ResourcesTool.LoadPrefabUI("item_ui"), transform).AddComponent<UIItem>();
                    } // end if
                    if (!item.gameObject.activeSelf) item.gameObject.SetActive(true);
                    // end if
                    item.SetSprite(sprite);
                    item.SetCount(count);
                } // end SetUIItem

                public void HideItem() {
                    if (null != item) item.gameObject.SetActive(false);
                    // end if
                } // end HideItem

                #region /*************** 代理 ******************/
                public void AddAction(Action call) {
                    pointerDownCall += call;
                } // end AddAction

                public void RemoveAction(Action call) {
                    pointerDownCall -= call;
                } // end RemoveAction
                public void ClearAction() {
                    pointerDownCall = null;
                } // end ClearAction
                #endregion

                public void OnPointerDown(PointerEventData eventData) {
                    if (null == pointerDownCall) return;
                    // end if
                    pointerDownCall();
                } // end OnPointerDown

                public void OnPointerUp(PointerEventData eventData) {
                    if (null == pointerDownCall) return;
                    // end if
                    pointerDownCall();
                } // end OnPointerUp
            } // end class UICell 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider