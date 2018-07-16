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
	public class UICell : MonoBehaviour, IPointerDownHandler {
        private Action pointerDownCall;
        public UIItem item { get; private set; }

        public void SetUIItem(Sprite sprite, int count) {
            if (null == item) {
                item = ObjectTool.InstantiateGo("ItemUI", "UI/ItemUI", transform).AddComponent<UIItem>();
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
    } // end class UICell 
} // end namespace Solider