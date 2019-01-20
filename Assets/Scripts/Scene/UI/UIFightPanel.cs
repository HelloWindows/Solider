/*******************************************************************
 * FileName: UIFightPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.UI.Custom;
using UnityEngine;
using Framework.Manager;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIFightPanel : IFSMState {
                public string id { get { return "fight_panel_ui"; } }

                private RectTransform rectTransform;
                private GameObject gameObject;
                private UIBuffPanel buffPanel;
                private UISkillPanel skillPanel;
                private bool isShowBar;
                private Animator avatar;
                private UIMainCharacterInfoPanel mainCharacterPanel;
                private UILockCharacterInfoPanel lockCharacterPanel;

                public UIFightPanel() {
                } // end UIFightPanel

                public void DoBeforeEntering() {
                    isShowBar = false;
                    gameObject = ObjectTool.InstantiateGo("UIFightPanel", ResourcesTool.LoadPrefabUI(id), 
                        SceneManager.mainCanvas.rectTransform);
                    rectTransform = gameObject.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = SceneManager.mainCanvas.sizeDelta;
                    mainCharacterPanel = rectTransform.Find("MainCharacterInfoPanel").gameObject.AddComponent<UIMainCharacterInfoPanel>();
                    lockCharacterPanel = rectTransform.Find("LockCharacterInfoPanel").gameObject.AddComponent<UILockCharacterInfoPanel>();
                    lockCharacterPanel.gameObject.SetActive(false);
                    buffPanel = new UIBuffPanel(rectTransform.Find("BuffPanle") as RectTransform, new Vector2(35f, 35f));
                    avatar = rectTransform.Find("BarPanel").GetComponent<Animator>();
                    rectTransform.Find("BarPanel/BarBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickBarBtn(); });
                    rectTransform.Find("BarPanel/BtnList/InfoBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickInfoBtn);
                    rectTransform.Find("BarPanel/BtnList/PackBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickPackBtn);
                    rectTransform.Find("BarPanel/BtnList/SettingBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickSettingBtn);
                    rectTransform.Find("AttackBtn").gameObject.AddComponent<UIButton>().AddListener(OnClickAttackBtn);
                    skillPanel = new UISkillPanel(rectTransform);
                    GameObject joystickUI = ObjectTool.InstantiateGo("Joystick", ResourcesTool.LoadPrefabUI("joystick_ui"), rectTransform);
                    joystickUI.transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
                    joystickUI.GetComponent<RectTransform>().sizeDelta =  SceneManager.mainCanvas.sizeDelta;
                    if (null == SceneManager.mainCharacter) {
                        DebugTool.LogError(GetType() + "DoBeforeEntering SceneManager mainCharacter is null!");
                        return;
                    } // end if
                    string roleType = SceneManager.mainCharacter.info.characterData.roleType;
                    rectTransform.Find("AttackBtn").GetComponent<Image>().sprite = ResourcesTool.LoadSprite(roleType + "_attack");
                } // end DoBeforeEntering

                public void Act() {
                    buffPanel.Update();
                    skillPanel.Update();
                    mainCharacterPanel.Show();
                    lockCharacterPanel.Show();
                } // end Act

                public void Reason() {
                } // end Reason

                public void DoBeforeLeaving() {
                    if (null != skillPanel) skillPanel.Dispose();
                    // end if
                    if (null != buffPanel) buffPanel.Dispose();
                    // end if
                    if (null != gameObject) Object.Destroy(gameObject);
                    // end if
                } // end DoBeforeLeaving

                private void OnClickAttackBtn() {
                    SceneManager.mainCharacter.input.Broadcast(ClickEvent.OnAttack);
                } // end OnClickAttackBtn

                private void OnClickBarBtn() {
                    if (isShowBar) {
                        avatar.Play("Hide", 0, 0);
                        isShowBar = false;
                    } else {
                        avatar.Play("Show", 0, 0);
                        isShowBar = true;
                    } // end if
                } // end OnClickBarBtn

                private void OnClickInfoBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UIInfoPanel());
                } // end OnClickInfoBtn

                private void OnClickPackBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UIPackPanel());
                } // end OnClickInfoBtn

                private void OnClickSettingBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UISettingPanel());
                } // end OnClickSettingBtn
            } // end class UIFightPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider