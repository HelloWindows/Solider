/*******************************************************************
 * FileName: UIPackPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.Config.Item;
using Solider.Interface;
using Solider.Manager;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIPackPanel : IFSMState {
                public string id { get { return "UIPackPanel"; } }

                private Text infoText;
                private int currentGid;
                private string packName;
                private IPack currentPack;
                private UIGrid[] gridArray;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;

                public UIPackPanel() {
                    parent = SceneManager.mainCanvas.rectTransform;
                } // end UIPackPanel

                public UIPackPanel(RectTransform parent) {
                    this.parent = parent;
                } // end UIPackPanel

                private void OnToggleEquipment(bool isOn) {
                    if (!isOn) return;
                    // end if
                    SwitchPack(ConstConfig.EQUIP);
                } // end OnToggleEquipment

                private void OnToggleConsumable(bool isOn) {
                    if (!isOn) return;
                    // end if
                    SwitchPack(ConstConfig.CONSUME);
                } // end OnToggleEquipment

                private void OnToggleStuff(bool isOn) {
                    if (!isOn) return;
                    // end if
                    SwitchPack(ConstConfig.STUFF);
                } // end OnToggleEquipment

                private void OnTogglePrint(bool isOn) {
                    if (!isOn) return;
                    // end if
                    SwitchPack(ConstConfig.PRINT);
                } // end OnTogglePrint

                private void LoseItem() {
                    currentGid = -1;
                    infoText.text = "";
                } // end LoseItem

                private void SwitchPack(string name) {
                    LoseItem();
                    packName = name;
                    currentPack = GameManager.playerInfo.pack.GetItemPack(name);
                    for (int i = 0; i < gridArray.Length; i++) {
                        ItemInfo info = currentPack.GetItemInfoForGrid(i);
                        if (null == info) {
                            gridArray[i].HideItem();
                            continue;
                        } // end 
                        int count = currentPack.GetCountForGrid(i);
                        gridArray[i].SetUIItem(Resources.Load<Sprite>(info.spritepath), count);
                    } // end for
                } // end SwitchPack

                private void OnExchangeGrid(int gid, int target) {
                    currentPack.ExchangeGridInfoWithGid(gid, target);
                } // end OnExchangeGrid

                private void OnSelectedGrid(int id) {
                    ItemInfo info = currentPack.GetItemInfoForGrid(id);
                    if (null != info) {
                        currentGid = id;
                        infoText.text = info.ToString();
                    } else {
                        LoseItem();
                    }// end if
                } // end OnSelectedGrid

                private void OnArrangeBtn() {
                    currentPack.ArrangePack();
                    SwitchPack(packName);
                } // end OnArrangeBtn

                private void OnClickUseBtn() {
                    if (currentGid == -1) return;
                    // end if
                    currentPack.UseItemWithGid(currentGid);
                    SwitchPack(packName);
                } // end OnClickUseBtn

                private void OnClickDiscardBtn() {
                    if (currentGid == -1) return;
                    // end if
                    int count = currentPack.GetCountForGrid(currentGid);
                    UIConfirmNumBox box = ObjectTool.InstantiateGo("ConfirmNumBoxUI", "UI/Custom/ConfirmNumBoxUI", 
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIConfirmNumBox>();
                    if (count > 1) {
                        box.InitInfo("输入丢弃的数量", count);
                    } else {
                        box.InitInfo("确定丢弃该物品");
                    } // end if
                    box.AddAction(DiscardItem);
                } // end OnClickDiscardBtn

                private void DiscardItem(int value) {
                    currentPack.DiscardItem(currentGid, value);
                    SwitchPack(packName);
                } // end DiscardBtn

                private void OnClickCloseBtn() {
                    SceneManager.uiPanelFMS.TransitionPrev();
                } // end OnClickInfoBtn

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("PackPanelUI", "UI/Common/PackPanelUI", parent);
                    transform = gameObject.transform;
                    string prefix = "GridPanel/Grids/Grid_";
                    gridArray = new UIGrid[ConstConfig.GRID_COUNT];
                    infoText = transform.Find("InfoText").GetComponent<Text>();
                    infoText.fontSize = 10;
                    infoText.alignByGeometry = false;
                    LoseItem();
                    for (int i = 0; i < gridArray.Length; i++) {
                        int id = i;
                        gridArray[i] = transform.Find(prefix + i).gameObject.AddComponent<UIGrid>();
                        gridArray[i].AddAction(delegate () { OnSelectedGrid(id); });
                        gridArray[i].AddAction(OnExchangeGrid);
                        gridArray[i].SetID(i);
                    } // end for
                    OnToggleEquipment(true);
                    transform.Find("GridPanel/ToggleGroup/Equipment").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleEquipment);
                    transform.Find("GridPanel/ToggleGroup/Consumable").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleConsumable);
                    transform.Find("GridPanel/ToggleGroup/Stuff").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleStuff);
                    transform.Find("GridPanel/ToggleGroup/Blueprint").GetComponent<Toggle>().onValueChanged.AddListener(OnTogglePrint);
                    transform.Find("ArrangeBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnArrangeBtn(); });
                    transform.Find("UseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickUseBtn(); });
                    transform.Find("DiscardBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickDiscardBtn(); });
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) { 
                } // end Act
            } // end class UIPackPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider