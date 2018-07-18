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
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnClickRegisterBtn");
#endif
                } // end OnClickRegisterBtn

                /// <summary>
                /// 点击登录按钮
                /// </summary>
                void OnClickLoginBtn() {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnClickLoginBtn");
#endif
                    SceneLoader.LoadNextLevel(new SelectRoleScene());
                } // end OnClickLoginBtn

                /// <summary>
                /// 点击QQ登录按钮
                /// </summary>
                void OnClickQQLoginBtn() {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnClickQQLoginBtn");
#endif
                    InstanceMgr.GetShareSDKManager().Authorize(PlatformType.QQ);
                } // end OnClickQQLoginBtn

                /// <summary>
                /// 点击微信登录按钮
                /// </summary>
                void OnClickWXLoginBtn() {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnClickWXLoginBtn");
#endif
                } // end OnClickWXLoginBtn

                /// <summary>
                /// 点击退出按钮
                /// </summary>
                void OnClickQuitBtn() {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnClickQuitBtn");
#endif
                } // end OnClickQuitBtn

                /// <summary>
                /// 点击自动登录
                /// </summary>
                void OnChangeAutoLoginToggle(bool isOn) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole(isOn.ToString());
#endif
                } // end OnChangeAutoLoginToggle
            } // end class UILoginPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider