/*******************************************************************
 * FileName: MainCamera.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Interface.View;
using Solider.Character.Interface;
using System;
using UnityEngine;

namespace Framework {
    namespace Custom {
        namespace View {
            public class MainCamera : IMainCamera, IDisposable {
                private ICharacter target;//目标物体
                private float smoothing = 3;//平滑系数
                public Camera camera { get; private set; }

                public MainCamera() {
                    GameObject Go = new GameObject("MainCamera");
                    camera = Go.AddComponent<Camera>();
                    camera.tag = "MainCamera";
                    camera.clearFlags = CameraClearFlags.Skybox;
                    camera.cullingMask = ~LayerConfig.Mask_UI; // 不显示UI层
                    camera.orthographic = false;
                    camera.fieldOfView = 60f;
                    ConsoleTool.SetConsole(camera.fieldOfView.ToString());
                    camera.depth = -1;
                    camera.renderingPath = RenderingPath.UsePlayerSettings;
                    Go.AddComponent<GUILayer>();
                    Go.AddComponent<FlareLayer>();
                    Go.AddComponent<AudioListener>();
                } // end MainCamera

                public void LateUpdate() {
                    if (null == target) return;
                    // end if
                    //目标物体要到达的目标位置 = 当前物体的位置 + 当前摄像机的位置
                    Vector3 targetPos = target.position + new Vector3(0, 6, -6);
                    //使用线性插值计算让摄像机用smoothing * Time.deltaTime时间从当前位置到移动到目标位置
                    camera.transform.position = targetPos;
                    //使用Quaternion.LookRotation方法可以计算出目标位置旋转后相机需要旋转的角度
                    Quaternion angle = Quaternion.LookRotation(target.position + Vector3.up * 0.5f - camera.transform.position);
                    //使用球形差值计算可以得到从当前的位置旋转到移动后的位置
                    camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, angle, smoothing * Time.deltaTime);
                } // end LateUpdate

                public void SetTarget(ICharacter target) {
                    this.target = target;
                } // end SetTarget

                public void Dispose() {
                    if (null != camera) UnityEngine.Object.Destroy(camera.gameObject);
                    // end if
                } // end Dispose
            } // end class MainCamera 
        } // end namespace View 
    } // end namespace Custom
} // end namespace Framework