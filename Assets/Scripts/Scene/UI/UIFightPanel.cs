/*******************************************************************
 * FileName: UIFightPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.UI.Custom;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIFightPanel : IFSMState {
                public string name { get; private set; }
                private IFSM fsm;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;

                public UIFightPanel(string name, IFSM fsm, RectTransform parent) {
                    this.fsm = fsm;
                    this.name = name;
                    this.parent = parent;
                } // end UIFightPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("TownPanelUI", "UI/Common/TownPanelUI", parent);
                    transform = gameObject.transform;
                    transform.Find("LoadBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickBarBtn(); });
                    transform.Find("PackBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickAttackBtn(); });
                    transform.Find("SettingBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickSkillBtn_0(); });
                    transform.Find("SettingBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickSkillBtn_1(); });
                    transform.Find("SettingBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickSkillBtn_2(); });
                } // end DoBeforeEntering

                public void Act(float deltaTime) {
                } // end Act

                public void Reason(float deltaTime) {
                } // end Reason

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                public void DoRemove() {
                } // end DoRemove

                private void OnClickBarBtn() {
                } // end OnClickBarBtn

                private void OnClickAttackBtn() {
                } // end OnClickAttackBtn

                private void OnClickSkillBtn_0() {
                } // end OnClickSkillBtn_0

                private void OnClickSkillBtn_1() {
                } // end OnClickSkillBtn_1

                private void OnClickSkillBtn_2() {
                } // end OnClickSkillBtn_2
            } // end class UIFightPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider