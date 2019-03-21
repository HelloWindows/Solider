/*******************************************************************
 * FileName: UIGrid.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIGrid : UIBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerDownHandler {
                private Action pointerDownCall;
                private Action<int, int> dropCall;

                public int id { get; private set; }
                public UIItem item { get; private set; }

                public void SetID(int id) { this.id = id; } // end SetID

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
                    if (null != item) {
                        item.SetCount(0);
                        item.gameObject.SetActive(false);
                    } // end if
                } // end HideItem

                public void OnBeginDrag(PointerEventData eventData) {
                    if (null == item || !item.gameObject.activeSelf) return;
                    // end if
                    item.transform.SetParent(SceneManager.mainCanvas.rectTransform);
                } // end OnBeginDrag

                public void OnDrag(PointerEventData eventData) {
                    if (null == item || false == item.gameObject.activeSelf) return;
                    // end if
                    Vector2 pos;
                    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(SceneManager.mainCanvas.rectTransform,
                        eventData.position, eventData.pressEventCamera, out pos))
                        item.transform.localPosition = pos;
                    // end if 
                } // end OnDrag

                public void OnEndDrag(PointerEventData eventData) {
                    if (null == item) return;
                    // end if
                    item.transform.SetParent(transform);
                    item.transform.localPosition = Vector3.zero;
                } // end OnEndDrag

                #region /*************** 选择格子 ******************/
                public void AddAction(Action call) {
                    pointerDownCall += call;
                } // end AddAction

                public void RemoveAction(Action call) {
                    pointerDownCall -= call;
                } // end RemoveAction

                public void OnPointerDown(PointerEventData eventData) {
                    if (null == pointerDownCall) return;
                    // end if
                    pointerDownCall();
                } // end OnPointerDown
                #endregion

                #region /*************** 置换格子 ******************/
                public void AddAction(Action<int, int> call) {
                    dropCall += call;
                } // end AddAction

                public void RemoveAction(Action<int, int> call) {
                    dropCall -= call;
                } // end RemoveAction

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
                    if (null == dropCall) return;
                    // end if
                    dropCall(id, grid.id);
                } // end OnDrop
                #endregion

                public void ClearAction() {
                    dropCall = null;
                    pointerDownCall = null;
                } // end ClearAction
            } // end class UIGrid 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Custom