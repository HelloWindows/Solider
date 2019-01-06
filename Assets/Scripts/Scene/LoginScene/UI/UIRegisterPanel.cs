/*******************************************************************
 * FileName: UIRegisterPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIRegisterPanel : IFSMState {
                private GameObject gameObject;
                private Transform transform;
                private InputField userNameInput;
                private InputField passwordInput;
                private InputField comfirmInput;
                private GameObject usernameWarningGo;
                private GameObject comfirmWarningGo;

                public string id { get { return "register_panel_ui"; } }

                public UIRegisterPanel() {
                } // end UIRegisterPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("RegisterPanelUI", ResourcesTool.LoadPrefabUI(id), 
                        SceneManager.mainCanvas.rectTransform);
                    transform = gameObject.transform;
                    userNameInput = transform.Find("UserNameInput").GetComponent<InputField>();
                    userNameInput.onEndEdit.AddListener(OnUserNameEndEdit);
                    userNameInput.text = "";
                    usernameWarningGo = userNameInput.transform.Find("Warning").gameObject;
                    usernameWarningGo.SetActive(false);

                    passwordInput = transform.Find("PasswordInput").GetComponent<InputField>();
                    passwordInput.inputType = InputField.InputType.Password;
                    comfirmInput = transform.Find("ComfirmInput").GetComponent<InputField>();
                    comfirmInput.inputType = InputField.InputType.Password;
                    comfirmWarningGo = comfirmInput.transform.Find("Warning").gameObject;
                    comfirmWarningGo.SetActive(false);

                    comfirmInput.onEndEdit.AddListener(OnComfirmEndEdit);
                    transform.Find("RegisterBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickRegisterBtn);
                    transform.Find("BackBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickBackBtn);
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                    gameObject = null;
                    transform = null;
                } // end DoBeforeLeaving

                public void Act() {
                } // end Act

                public void Reason() {
                } // end Reason

                private void OnUserNameEndEdit(string name) {
                    if (userNameInput.text == "" || userNameInput.text == null) return;
                    // end if
                    if (true == SqliteManager.CheckUserName(userNameInput.text)) {
                        usernameWarningGo.SetActive(true);
                    } else if (usernameWarningGo.activeSelf) {
                        usernameWarningGo.SetActive(false);
                    } // end if
                } // end OnUserNameEndEdit

                private void OnComfirmEndEdit(string passwords) {
                    if (passwordInput.text == "" || passwordInput.text == null ||
                        comfirmInput.text == "" || comfirmInput.text == null) return;
                    // end if
                    if (passwordInput.text != comfirmInput.text) {
                        comfirmWarningGo.SetActive(true);
                    } else if (comfirmWarningGo.activeSelf) {
                        comfirmWarningGo.SetActive(false);
                    } // end if
                } // end OnComfirmEndEdit

                private void OnClickRegisterBtn() {
                    if (userNameInput.text == "" || userNameInput.text == null || 
                        passwordInput.text == "" || passwordInput.text == null ||
                        comfirmInput.text == "" || comfirmInput.text == null) return;
                    // end if
                    if (passwordInput.text != comfirmInput.text) {
                        comfirmWarningGo.SetActive(true);
                        return;
                    } else if (comfirmWarningGo.activeSelf) {
                        comfirmWarningGo.SetActive(false);
                    } // end if
                    if (false == SqliteManager.RegisterPlayer(userNameInput.text, comfirmInput.text)) {
                        ObjectTool.InstantiateGo("MessageBoxUI", ResourcesTool.LoadPrefabUI("message_box_ui"),
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("注册失败");
                    } else {
                        ObjectTool.InstantiateGo("MessageBoxUI", ResourcesTool.LoadPrefabUI("message_box_ui"),
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("注册成功", OnClickBackBtn);
                    } // end if
                } // end OnClickRegisterBtn

                private void OnClickBackBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UILoginPanel());
                } // end OnClickBackBtn
            } // end class UIRegisterPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider