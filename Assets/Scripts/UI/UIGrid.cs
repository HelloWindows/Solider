/*******************************************************************
 * FileName: UIGrid.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using Solider.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solider {
	public class UIGrid : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler {

        public int id { get; private set; }
        public UIItem item { get; private set; }

        public void SetID(int id) { this.id = id; } // end SetIndex

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

        public void OnBeginDrag(PointerEventData eventData) {
            if (null == item || !item.gameObject.activeSelf) return;
            // end if
            item.transform.SetParent(CanvasManager.MainCanvasTrans);
        } // end OnBeginDrag

        public void OnDrag(PointerEventData eventData) {
            if (null == item || false == item.gameObject.activeSelf) return;
            // end if
            Vector2 pos;
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasManager.MainCanvasTrans,
                eventData.position, Camera.main, out pos))
                item.transform.localPosition = pos;
            // end if 
        } // end OnDrag

        public void OnEndDrag(PointerEventData eventData) {
            if (null == item) return;
            // end if
            item.transform.SetParent(transform);
            item.transform.localPosition = Vector3.zero;
        } // end OnEndDrag

        public void OnDrop(PointerEventData eventData) {
            if (null == eventData.pointerDrag) return; 
            // end if
            UIGrid grid = eventData.pointerDrag.GetComponent<UIGrid>();
            if (null == grid || null == grid.item || false == grid.item.gameObject.activeSelf) return;
            // end if
            Sprite sprite = grid.item.sprite;
            int count = grid.item.count;
            if (null == item || !item.gameObject.activeSelf) {
                grid.HideItem();

            } else {
                grid.SetUIItem(item.sprite, item.count);
            } // end if
            SetUIItem(sprite, count);
            PlayerManager.pack.ExchangeEquipInfoWithGid(id, grid.id);
        } // end OnDrop
    } // end class UIGrid 
} // end namespace Custom