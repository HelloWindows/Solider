/*******************************************************************
 * FileName: UIScrollView.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.UI;
using Framework.DataStructure;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIScrollView {
                private int index;
                private int maxIndex;
                private float lastDrag;
                private ScrollRect scrollRect;
                private TWQueue<UIScrollItem> itemQueue;
                private const int gap = 125;
                private int indexGap;

                public UIScrollView(ScrollRect scrollRect) {
                    index = 0;
                    lastDrag = 0;
                    maxIndex = 100;
                    this.scrollRect = scrollRect;
                    itemQueue = new TWQueue<UIScrollItem>();
                    scrollRect.content.sizeDelta = new Vector2(383, maxIndex * 125);
                    int count = Mathf.Clamp(maxIndex, 0, 4);
                    indexGap = count - 1;
                    for (int i = 0; i < count; i++) {
                        UIScrollItem item = new UIScrollItem(scrollRect.content, 
                            new Vector3(0, -62.5f - i * 125f, 0), OnClickItem);
                        item.ResetItem(index.ToString(), null, index.ToString());
                        itemQueue.Enqueue(item);
                        index++;
                    } // end for
                    scrollRect.verticalScrollbar.onValueChanged.AddListener(delegate (float value) { OnDrag(value); });
                } // end Start

                private void OnDrag(float value) {
                    if (value < lastDrag) {
                        DragUp(scrollRect.content.localPosition.y);
                    } else {
                        DragDown(scrollRect.content.localPosition.y);
                    }// end if
                    lastDrag = value;
                } // end OnDrag

                private void OnClickItem(string itemID) {

                } // end OnClickItem

                private void DragUp(float value) {
                    if (index >= maxIndex) return;
                    // end if
                    if (value > (index - indexGap) * gap) {
                        UIScrollItem item = itemQueue.Dequeue();
                        item.SetBotton();
                        item.ResetItem(index.ToString(), null, index.ToString());
                        itemQueue.Enqueue(item);
                        index++;
                    } // end if
                } // end DragUp

                private void DragDown(float value) {
                    if (index <= indexGap + 1) return;
                    // end if
                    if (value < (index - indexGap - 1) * gap) {
                        UIScrollItem item = itemQueue.DequeueRev();
                        item.SetTop();
                        item.ResetItem(index.ToString(), null, (index - indexGap - 2).ToString());
                        itemQueue.EnqueueRev(item);
                        index--;
                    } // end if
                } // end DragDown
            } // end class UIScrollView 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider