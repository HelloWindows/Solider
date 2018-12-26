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

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIFightPanel : IFSMState {
                public string id { get { return "UIFightPanel"; } }

                private RectTransform transform;
                private RectTransform parent;
                private GameObject gameObject;
                private UIBuffPanel buffPanel;
                private UISkillPanel skillPanel;

                public UIFightPanel() {
                    parent = SceneManager.uiCanvas.rectTransform;
                } // end UIFightPanel

                public UIFightPanel(RectTransform parent) {
                    this.parent = parent;
                } // end UIFightPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("UIFightPanel", "UI/Common/FightPanelUI", parent);
                    transform = gameObject.GetComponent<RectTransform>();
                    buffPanel = new UIBuffPanel(transform.Find("BuffPanle") as RectTransform, new Vector2(35f, 35f));    
                    transform.Find("BarBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickBarBtn(); });
                    transform.Find("AttackBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickAttackBtn);
                    skillPanel = new UISkillPanel(transform);
                    GameObject ioystickUI = ObjectTool.InstantiateGo("MainPanelUI", "UI/Common/JoystickUI", transform);
                    ioystickUI.transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
                } // end DoBeforeEntering

                public void Act() {
                    buffPanel.Update();
                    skillPanel.Update();
                } // end Act

                public void Reason() {
                } // end Reason

                public void DoBeforeLeaving() {
                    if (null != skillPanel) skillPanel.Dispose();
                    // end if
                    if (null != buffPanel) buffPanel.Dispose();
                    // end if
                } // end DoBeforeLeaving

                private void OnClickAttackBtn() {
                    SceneManager.mainCharacter.input.Broadcast(ClickEvent.OnAttack);
                } // end OnClickAttackBtn

                private void OnClickBarBtn() {
                } // end OnClickBarBtn
            } // end class UIFightPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider