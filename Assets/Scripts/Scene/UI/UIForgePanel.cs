/*******************************************************************
 * FileName: UIForgePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.Config.Item;
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
                private BluePrintInfo printInfo;

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
                    printInfo = info;
                    buleprint.SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
                    int number = info.stuffCountArr.Length;
                    int x = (number - 1) * 40;
                    for (int i = 0; i < stuffArray.Length; i++) {
                        if (i < number) {
                            stuffArray[i].transform.localPosition = new Vector3((x - 80 * i), 0, 0);
                            stuffArray[i].gameObject.SetActive(true);
                            ItemInfo stuff = Configs.itemConfig.GetItemInfo(info.stuffIDArr[i]);
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
                    if (null == printInfo) {
                        ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("请选择制作图！");
                        return;
                    } // end if
                    if (GameManager.playerInfo.pack.GetItemPack(ConstConfig.EQUIP).IsFull) {
                        ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("装备背包已满！");
                        return;
                    } // end if
                    for (int i = 0; i < printInfo.stuffIDArr.Length; i++) {
                        if (false == GameManager.playerInfo.pack.GetItemPack(ConstConfig.STUFF).EnoughWithIDAndCount(
                            printInfo.stuffIDArr[i], printInfo.stuffCountArr[i])) {
                            ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                                SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("材料不够！");
                            return;
                        } // end if
                    } // end for
                    GameManager.playerInfo.pack.GetItemPack(ConstConfig.PRINT).ExpendItemWithID(printInfo.id, 1);
                    for (int i = 0; i < printInfo.stuffIDArr.Length; i++) {
                        GameManager.playerInfo.pack.GetItemPack(ConstConfig.STUFF).ExpendItemWithID(
                            printInfo.stuffIDArr[i], printInfo.stuffCountArr[i]);
                    } // end for
                    GameManager.playerInfo.pack.GetItemPack(ConstConfig.EQUIP).PackItem(printInfo.targetID, 1);
                    printInfo = null;
                    buleprint.SetUIItem(null, 0);
                    for (int i = 0; i < stuffArray.Length; i++) {
                        stuffArray[i].gameObject.SetActive(false);
                    } // end for
                    for (int i = 0; i < cellArray.Length; i++) {
                        if (null == blueprintPack.GetItemInfoForGrid(i)) cellArray[i].HideItem();
                        // end if
                    } // end for
                    ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("锻造成功！");
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