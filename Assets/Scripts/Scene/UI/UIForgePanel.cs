/*******************************************************************
 * FileName: UIForgePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Config;
using Solider.Interface;
using Solider.Manager;
using Solider.UI.Custom;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIForgePanel : IFSMState {
                public string name { get; private set; }
                private IFSM fsm;
                private IPack blueprintPack;
                private RectTransform parent;
                private GameObject gameObject;
                private Transform transform { get { return gameObject.transform; } }
                private UICell buleprint;
                private UICell[] cellArray;
                private UICell[] stuffArray;

                public UIForgePanel(string name, IFSM fsm, RectTransform parent) {
                    this.fsm = fsm;
                    this.name = name;
                    this.parent = parent;
                } // end UISettingPanel

                public void DoBeforeEntering() {
                    stuffArray = new UICell[4];
                    cellArray = new UICell[ConstConfig.GRID_COUNT];
                    blueprintPack = GameManager.playerInfo.pack.GetItemPack(ConstConfig.PRINT);
                    gameObject = ObjectTool.InstantiateGo("ForgePanelUI", "UI/Common/ForgePanelUI", parent);
                    buleprint = transform.Find("Blueprint/Print").gameObject.AddComponent<UICell>();
                    for (int i = 0; i < cellArray.Length; i++) {
                        cellArray[i] = transform.Find("GridPanel/Grids/Grid_" + i).gameObject.AddComponent<UICell>();
                        ItemInfo info = blueprintPack.GetItemInfoForGrid(i);
                        if (null == info) {
                            cellArray[i].HideItem();
                            continue;
                        } // end 
                        int id = i;
                        cellArray[i].AddAction(delegate () { OnSelectedGrid(id); });
                        cellArray[i].SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
                    } // end for
                    for (int i = 0; i < stuffArray.Length; i++) {
                        stuffArray[i] = transform.Find("Blueprint/Stuff_" + i).gameObject.AddComponent<UICell>();
                        stuffArray[i].gameObject.SetActive(false);
                    } // end for
                    transform.Find("ForgeBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickForgeBtn(); });
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
                } // end DoBeforeEntering

                private void OnSelectedGrid(int id) {
                    BluePrintInfo info = blueprintPack.GetItemInfoForGrid(id) as BluePrintInfo;
                    if (null == info) return;
                    // end if
                    buleprint.SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
                    int number = info.stuffCountArr.Length;
                    int x = (number - 1) * 40;
                    for (int i = 0; i < stuffArray.Length; i++) {
                        if (i < number) {
                            stuffArray[i].transform.localPosition = new Vector3((x - 80 * i), 0, 0);
                            stuffArray[i].gameObject.SetActive(true);
                            ItemInfo stuff = ItemConfig.instance.GetItemInfo(info.stuffIDArr[i]);
                            if (null == stuff) continue;
                            // end if
                            stuffArray[i].SetUIItem(Resources.Load<Sprite>(stuff.spritepath), 0);
                            int numerator = GameManager.playerInfo.pack.GetItemPack(ConstConfig.STUFF).GetCountForID(stuff.id);
                            stuffArray[i].item.SetPercent(numerator, info.stuffCountArr[i]);
                            continue;
                        } // end if
                        stuffArray[i].gameObject.SetActive(false);
                    } // end for
                } // end OnSelectedGrid

                private void OnClickCloseBtn() {
                    fsm.PerformTransition("UITownPanel");
                } // end OnClickInfoBtn

                private void OnClickForgeBtn() {

                } // end OnClickForgeBtn

                public void DoRemove() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoRemove

                public void DoBeforeLeaving() {
                    DoRemove();
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason 

                public void Act(float deltaTime) {
                } // end Act
            } // end class UIForgePanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider