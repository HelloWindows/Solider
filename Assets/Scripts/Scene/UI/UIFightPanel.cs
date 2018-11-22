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
using Framework.Broadcast;
using Framework.Manager;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIFightPanel : IFSMState {
                public string name { get { return "UIFightPanel"; } }
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;
                private UIBuffPanel buffPanel;

                public UIFightPanel() {
                    parent = SceneManager.mainCanvas.rectTransform;
                } // end UIFightPanel

                public UIFightPanel(RectTransform parent) {
                    this.parent = parent;
                } // end UIFightPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("UIFightPanel", "UI/Common/FightPanelUI", parent);
                    transform = gameObject.transform;
                    buffPanel = new UIBuffPanel(transform.Find("BuffPanle") as RectTransform, new Vector2(35f, 35f));
                    BroadcastCenter.AddListener(BroadcastType.BuffChange, buffPanel.FreshenIcon);
                    transform.Find("BarBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickBarBtn(); });
                    transform.Find("AttackBtn").gameObject.AddComponent<UIButtonCode>().SetButtonCode(ButtonCode.ATTACK);
                    transform.Find("SkillBtn_0").gameObject.AddComponent<UIButtonCode>().SetButtonCode(ButtonCode.SKILL_1);
                    transform.Find("SkillBtn_1").gameObject.AddComponent<UIButtonCode>().SetButtonCode(ButtonCode.SKILL_2);
                    transform.Find("SkillBtn_2").gameObject.AddComponent<UIButtonCode>().SetButtonCode(ButtonCode.SKILL_3);
                    GameObject ioystickUI = ObjectTool.InstantiateGo("MainPanelUI", "UI/Common/JoystickUI", transform);
                    ioystickUI.transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
                } // end DoBeforeEntering

                public void Act(float deltaTime) {
                    buffPanel.Update();
                } // end Act

                public void Reason(float deltaTime) {
                } // end Reason

                public void DoBeforeLeaving() {
                    BroadcastCenter.RemoveListener(BroadcastType.BuffChange, buffPanel.FreshenIcon);
                } // end DoBeforeLeaving

                private void OnClickBarBtn() {
                } // end OnClickBarBtn
            } // end class UIFightPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider