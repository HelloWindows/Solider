/*******************************************************************
 * FileName: UIGrid.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solider {
	public class UIGrid : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

        public int Index { get; private set; }
        private UIItem item;

        public void SetIndex(int index) { Index = index; } // end SetIndex

        public void SetUIItem(string spritePath, int count) {
            if (null == item) {
                item = ObjectTool.InstantiateGo("ItemUI", "UI/ItemUI", transform).AddComponent<UIItem>();
            } // end if
            if (!item.gameObject.activeSelf) item.gameObject.SetActive(true);
            // end if
            item.SetSprite(Resources.Load<Sprite>(spritePath));
            item.SetCount(count);
        } // end SetUIItem

        public void HideItem() {
            if (null != item) item.gameObject.SetActive(false);
            // end if
        } // end HideItem

        public void OnBeginDrag(PointerEventData eventData) {

        } // end OnBeginDrag

        public void OnDrag(PointerEventData eventData) {
            if (null == item) return;
            // end if
        } // end OnDrag

        public void OnEndDrag(PointerEventData eventData) {
            Debug.Log(gameObject.name + ": OnEndDrag " + eventData.pointerCurrentRaycast.gameObject.name);
        } // end OnEndDrag
    } // end class UIGrid 
} // end namespace Custom