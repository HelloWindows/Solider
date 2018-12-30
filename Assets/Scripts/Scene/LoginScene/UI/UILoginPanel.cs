/*******************************************************************
 * FileName: UILoginPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Middleware;
using Framework.Tools;
using Solider.Manager;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UILoginPanel : IFSMState {
                private GameObject gameObject;
                private Transform transform;
                private RectTransform parent;
                private InputField userNameInput;
                private InputField passwordInput;

                public string id { get { return "UILoginPanel"; } }

                public UILoginPanel() {
                    parent = SceneManager.mainCanvas.rectTransform;
                } // end UILoginPanel

                public UILoginPanel(RectTransform parent) {
                    this.parent = parent;
                } // end UILoginPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("LoginPanelUI", "Scene/LoginScene/LoginPanelUI", parent);
                    transform = gameObject.transform;
                    userNameInput = transform.Find("UserNameInput").GetComponent<InputField>();
                    userNameInput.text = "";
                    passwordInput = transform.Find("PasswordInput").GetComponent<InputField>();
                    passwordInput.inputType = InputField.InputType.Password;
                    passwordInput.text = "";
                    transform.Find("RegisterBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickRegisterBtn);
                    transform.Find("LoginBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickLoginBtn);
                    transform.Find("QQLoginBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickQQLoginBtn);
                    transform.Find("WXLoginBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickWXLoginBtn);
                    transform.Find("QuitBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickQuitBtn);
                } // end DoBeforeEntering
                /// <summary>
                /// 点击注册按钮
                /// </summary>
                void OnClickRegisterBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UIRegisterPanel());
                } // end OnClickRegisterBtn

                /// <summary>
                /// 点击登录按钮
                /// </summary>
                void OnClickLoginBtn() {
                    if (userNameInput.text == "" || userNameInput.text == null ||
                        passwordInput.text == "" || passwordInput.text == null) {
                        ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("请输入正确的账号密码!");
                        return;
                    } // end if
                    string msg = "";
                    string username = userNameInput.text;
                    if (SqliteManager.CheckLogin(username, passwordInput.text, out msg)) {
                        ConsoleTool.SetConsole(msg);
                        GameManager.playerInfo.LoginGame(username);
                        LoaderScene.LoadNextLevel(new SelectRoleScene());
                        return;
                    } // end if
                    ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage(msg);
                } // end OnClickLoginBtn

                /// <summary>
                /// 点击QQ登录按钮
                /// </summary>
                void OnClickQQLoginBtn() {
                    ConsoleTool.SetConsole("OnClickQQLoginBtn");
                } // end OnClickQQLoginBtn

                /// <summary>
                /// 点击微信登录按钮
                /// </summary>
                void OnClickWXLoginBtn() {
                    ConsoleTool.SetConsole("OnClickWXLoginBtn");
                } // end OnClickWXLoginBtn

                /// <summary>
                /// 点击退出按钮
                /// </summary>
                void OnClickQuitBtn() {
                    ConsoleTool.SetConsole("OnClickQuitBtn");
                } // end OnClickQuitBtn

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                    gameObject = null;
                    transform = null;
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason

                public void Act() {
                } // end Act
            } // end class UILoginPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider