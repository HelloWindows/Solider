/*******************************************************************
 * FileName: ShareSDKManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using cn.sharesdk.unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Manager {
        public class ShareSDKManager : MonoBehaviour {

            public static ShareSDKManager instance { get; private set; }
            private ShareSDK ssdk;

            private void Awake() {
                instance = this;
            } // end Awake

            private void Start() {
                ssdk = GetComponent<ShareSDK>();
                ssdk.authHandler = AuthResultHandler;
                ssdk.showUserHandler = GetUserInfoResultHandler;
                ssdk.shareHandler = ShareResultHandler;
            } // end Start

            /// <summary>
            /// 授权
            /// </summary>
            /// <param name="platform"></param>
            public void Authorize(PlatformType platform) {
                ssdk.Authorize(platform);
            } // end Authorize

            /// <summary>
            /// 获取用户信息
            /// </summary>
            /// <param name="platform"></param>
            public void GetUserInfo(PlatformType platform) {
                ssdk.GetUserInfo(platform);
            } // end GetUserInfo

            /// <summary>
            /// 分享
            /// </summary>
            public void ShareInfo(PlatformType[] platforms, ShareContent content, int x, int y) {
                ssdk.ShowPlatformList(platforms, content, x, y);
            } // end 

            /// <summary>
            /// 授权回调
            /// </summary>
            /// <param name="reqID"></param>
            /// <param name="state"> 响应状态 </param>
            /// <param name="type"> 授权平台 </param>
            /// <param name="result"> 回调内容 </param>
            void AuthResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result) {

                if (state == ResponseState.Success) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("authorize success !");
#endif
                } else if (state == ResponseState.Fail) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("fail! throwable stack = " + result["stack"] + "; error msg = " + result["msg"]);
#endif
                }
                else if (state == ResponseState.Cancel) {
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("cancel");
#endif
                } // end if
            } // end AuthResultHandler

            /// <summary>
            /// 获取用户信息回调
            /// </summary>
            /// <param name="reqID"></param>
            /// <param name="state"> 响应状态 </param>
            /// <param name="type"> 授权平台 </param>
            /// <param name="result"> 回调内容 </param>
            void GetUserInfoResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result) {

                if (state == ResponseState.Success) {
                    print("get user info result :");
                    print(MiniJSON.jsonEncode(result));
                } else if (state == ResponseState.Fail) {
                    print("fail! throwable stack = " + result["stack"] + "; error msg = " + result["msg"]);
                } else if (state == ResponseState.Cancel) {
                    print("cancel !");
                } // end if
            } // end GetUserInfoResultHandler

            /// <summary>
            /// 分享回调
            /// </summary>
            /// <param name="reqID"></param>
            /// <param name="state"></param>
            /// <param name="type"></param>
            /// <param name="result"></param>
            void ShareResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result) {

                if (state == ResponseState.Success) {
                    print("share result :");
                    print(MiniJSON.jsonEncode(result));
                } else if (state == ResponseState.Fail) {
                    print("fail! throwable stack = " + result["stack"] + "; error msg = " + result["msg"]);
                } else if (state == ResponseState.Cancel) {
                    print("cancel !");
                } // end if
            } // end ShareResultHandler
        } // end class ShareSDKManager 
    } // end namespace Manager
} // end namespace Framework