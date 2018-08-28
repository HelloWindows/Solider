/*******************************************************************
 * FileName: UIScrollView.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIScrollView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {
                private int index;
                private int maxIndex;
                private float smooth;
                private UIScrollItem[] itemArr;
                private float lastDrag;

                private void Start() {
                    index = 0;
                    smooth = 0;
                    maxIndex = 10;
                    itemArr = new UIScrollItem[4];
                    for (int i = 0; i < itemArr.Length; i++) {
                        itemArr[i] = new UIScrollItem(transform as RectTransform, new Vector3(0, (1 - i) * 125, 0),
                            delegate (string itemID) { OnClickItem(itemID); });
                        itemArr[i].ResetItem(null, index.ToString());
                        index++;
                    } // end for
                } // end Start

                public void OnPointerDown(PointerEventData data) {
                    lastDrag = data.position.y;
                } // end OnPointerDown

                public void OnPointerUp(PointerEventData eventData) {
                    smooth = 0f;
                } // end OnPointerUp

                public void OnDrag(PointerEventData data) {
                    float interval = data.position.y - lastDrag;
                    if (interval > 0) {
                        DragUp(interval);
                    } else if(interval < 0) {
                        DragDowm(-interval);
                    } // end if
                    lastDrag = data.position.y;
                } // end OnDrag

                private void OnClickItem(string itemID) {
                } // end OnClickItem

                private void DragUp(float interval) {
                    for (int i = 0; i < itemArr.Length; i++) {
                        if(itemArr[i].ScrollUp(interval)) continue;
                        // end if
                        itemArr[i].ResetItem(null, index.ToString());
                        if(index + 1 < maxIndex) itemArr[i].SetBotton();
                        // end if
                        index++;
                    } // end for
                } // end DragUp

                private void DragDowm(float interval) {
                    for (int i = 0; i < itemArr.Length; i++) {
                        if(itemArr[i].ScorllDown(interval)) continue;
                        // end if
                        index--;
                        itemArr[i].ResetItem(null, (index - 4).ToString());
                        if(index > 3) itemArr[i].SetTop();
                        // end if
                    } // end for
                } // end DragUp

                private void MoveUp(float interval) {
                    for (int i = 0; i < itemArr.Length; i++) {
                        itemArr[i].ScrollUp(interval);
                    } // end for
                } // end MoveUp

                private void MoveDown(float interval) {
                    for (int i = 0; i < itemArr.Length; i++) {
                        itemArr[i].ScorllDown(interval);
                    } // end for
                } // end MoveUp
            } // end class UIScrollView 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider