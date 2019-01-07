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
using Solider.Config.Interface;
using Solider.Manager;
using Solider.Model.Interface;
using Solider.UI.Custom;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIForgePanel : IFSMState {
                public string id { get { return "UIForgePanel"; } }

                private IPack blueprintPack;
                private RectTransform parent;
                private GameObject gameObject;
                private Transform transform { get { return gameObject.transform; } }
                private UICell buleprint;
                private UICell[] cellArray;
                private UICell[] stuffArray;
                private IBluePrintInfo printInfo;

                public UIForgePanel() {
                    this.parent = SceneManager.mainCanvas.rectTransform;
                } // end UISettingPanel

                public UIForgePanel(RectTransform parent) {
                    this.parent = parent;
                } // end UISettingPanel

                public void DoBeforeEntering() {
                    stuffArray = new UICell[4];
                    cellArray = new UICell[ConstConfig.GRID_COUNT];
                    blueprintPack = SceneManager.mainCharacter.pack.GetItemPack(ConstConfig.PRINT);
                    gameObject = ObjectTool.InstantiateGo("ForgePanelUI", "UI/Common/ForgePanelUI", parent);
                    buleprint = transform.Find("Blueprint/Print").gameObject.AddComponent<UICell>();
                    for (int i = 0; i < cellArray.Length; i++) {
                        cellArray[i] = transform.Find("GridPanel/Grids/Grid_" + i).gameObject.AddComponent<UICell>();
                        string itemID = blueprintPack.GetItemIDForGrid(i);
                        IItemInfo info = Configs.itemConfig.GetItemInfo(itemID);
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
                    transform.Find("ForgeBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickForgeBtn(); });
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickCloseBtn(); }, "ui_close");
                } // end DoBeforeEntering

                private void OnSelectedGrid(int id) {
                    string itemID = blueprintPack.GetItemIDForGrid(id);
                    IBluePrintInfo info = Configs.itemConfig.GetItemInfo(itemID) as IBluePrintInfo;
                    if (null == info) return;
                    // end if
                    printInfo = info;
                    buleprint.SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
                    int number = info.stuffNumber;
                    int x = (number - 1) * 40;
                    for (int i = 0; i < stuffArray.Length; i++) {
                        if (i < number) {
                            string stuffID = "";
                            if (false == info.TryGetStuffID(i, out stuffID)) continue;
                            // end if
                            IItemInfo stuff = Configs.itemConfig.GetItemInfo(stuffID);
                            if (null == stuff) continue;
                            // end if
                            int stuffCount = 0;
                            if (false == info.TryGetStuffCount(i, out stuffCount)) continue;
                            // end if
                            stuffArray[i].transform.localPosition = new Vector3((x - 80 * i), 0, 0);
                            stuffArray[i].gameObject.SetActive(true);
                            int numerator = SceneManager.mainCharacter.pack.GetItemPack(ConstConfig.STUFF).GetCountForID(stuff.id);
                            stuffArray[i].SetUIItem(Resources.Load<Sprite>(stuff.spritepath), 0);
                            stuffArray[i].item.SetPercent(numerator, stuffCount);
                            continue;
                        } // end if
                        stuffArray[i].gameObject.SetActive(false);
                    } // end for
                } // end OnSelectedGrid

                private void OnClickCloseBtn() {
                    SceneManager.uiPanelFMS.TransitionPrev();
                } // end OnClickInfoBtn

                private void OnClickForgeBtn() {
                    if (null == printInfo) {
                        ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("请选择制作图！");
                        return;
                    } // end if
                    if (SceneManager.mainCharacter.pack.GetItemPack(ConstConfig.EQUIP).IsFull) {
                        ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("装备背包已满！");
                        return;
                    } // end if
                    for (int i = 0; i < printInfo.stuffNumber; i++) {
                        string stuffID = "";
                        int stuffCount = 0;
                        if (false == printInfo.TryGetStuffID(i, out stuffID) ||
                            false == printInfo.TryGetStuffCount(i, out stuffCount)) {
                            ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                                SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("系统错误！");
                            return;
                        } // end if
                        if (false == SceneManager.mainCharacter.pack.GetItemPack(ConstConfig.STUFF).EnoughWithIDAndCount(stuffID, stuffCount)) {
                            ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                                SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("材料不够！");
                            return;
                        } // end if
                    } // end for
                    SceneManager.mainCharacter.pack.GetItemPack(ConstConfig.PRINT).ExpendItemWithID(printInfo.id, 1);
                    for (int i = 0; i < printInfo.stuffNumber; i++) {
                        string stuffID = "";
                        int stuffCount = 0;
                        if (false == printInfo.TryGetStuffID(i, out stuffID) ||
                            false == printInfo.TryGetStuffCount(i, out stuffCount)) {
                            ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                                SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("系统错误！");
                            return;
                        } // end if
                        SceneManager.mainCharacter.pack.GetItemPack(ConstConfig.STUFF).ExpendItemWithID(stuffID, stuffCount);
                    } // end for
                    SceneManager.mainCharacter.pack.GetItemPack(ConstConfig.EQUIP).PackItem(printInfo.targetID, 1);
                    printInfo = null;
                    buleprint.SetUIItem(null, 0);
                    for (int i = 0; i < stuffArray.Length; i++) {
                        stuffArray[i].gameObject.SetActive(false);
                    } // end for
                    for (int i = 0; i < cellArray.Length; i++) {
                        string itemID = blueprintPack.GetItemIDForGrid(i);
                        if (null == Configs.itemConfig.GetItemInfo(itemID)) cellArray[i].HideItem();
                        // end if
                    } // end for
                    ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("锻造成功！");
                } // end OnClickForgeBtn

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason 

                public void Act() {
                } // end Act
            } // end class UIForgePanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider