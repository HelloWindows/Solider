/*******************************************************************
 * FileName: Test.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Solider.Config;
using Solider.Model;
using Framework.Manager;

namespace Solider {
    public class Test : MonoBehaviour {
        public Transform target;//目标物体
        public float smoothing = 3;//平滑系数

        private void Start() {
            InstanceMgr.Init();
            ConsoleTool.SetConsole("Test");
        } // end Start

        void LateUpdate() {
            //目标物体要到达的目标位置 = 当前物体的位置 + 当前摄像机的位置
            Vector3 targetPos = target.position + new Vector3(0, 4, -4);
            //使用线性插值计算让摄像机用smoothing * Time.deltaTime时间从当前位置到移动到目标位置
            this.transform.position = targetPos;
            //使用Quaternion.LookRotation方法可以计算出目标位置旋转后相机需要旋转的角度
            Quaternion angle = Quaternion.LookRotation(target.position + Vector3.up * 0.5f - transform.position);
            //使用球形差值计算可以得到从当前的位置旋转到移动后的位置
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, angle, smoothing * Time.deltaTime);
        }
    } // end class Test 
} // end namespace Solider