/*******************************************************************
 * FileName: UILoginPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using cn.sharesdk.unity3d;
using Framework.Manager;
using Framework.Middleware;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UILoginPanel : MonoBehaviour {
                private InputField userNameInput;
                private InputField passwordInput;

                // Use this for initialization
                void Start() {
                    transform.Find("AutoLoginToggle").GetComponent<Toggle>().onValueChanged.AddListener(OnChangeAutoLoginToggle);
                    transform.Find("RegisterBtn").GetComponent<Button>().onClick.AddListener(OnClickRegisterBtn);
                    transform.Find("LoginBtn").GetComponent<Button>().onClick.AddListener(OnClickLoginBtn);
                    transform.Find("QQLoginBtn").GetComponent<Button>().onClick.AddListener(OnClickQQLoginBtn);
                    transform.Find("WXLoginBtn").GetComponent<Button>().onClick.AddListener(OnClickWXLoginBtn);
                    transform.Find("QuitBtn").GetComponent<Button>().onClick.AddListener(OnClickQuitBtn);
                } // end Start

                /// <summary>
                /// 点击注册按钮
                /// </summary>
                void OnClickRegisterBtn() {
                    ConsoleTool.SetConsole("OnClickRegisterBtn");
                } // end OnClickRegisterBtn

                /// <summary>
                /// 点击登录按钮
                /// </summary>
                void OnClickLoginBtn() {
                    ConsoleTool.SetConsole("OnClickLoginBtn");
                    SceneLoader.LoadNextLevel(new SelectRoleScene());
                } // end OnClickLoginBtn

                /// <summary>
                /// 点击QQ登录按钮
                /// </summary>
                void OnClickQQLoginBtn() {
                    ConsoleTool.SetConsole("OnClickQQLoginBtn");
                    InstanceMgr.GetShareSDKManager().Authorize(PlatformType.QQ);
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

                /// <summary>
                /// 点击自动登录
                /// </summary>
                void OnChangeAutoLoginToggle(bool isOn) {
                    ConsoleTool.SetConsole(isOn.ToString());
                } // end OnChangeAutoLoginToggle
            } // end class UILoginPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider