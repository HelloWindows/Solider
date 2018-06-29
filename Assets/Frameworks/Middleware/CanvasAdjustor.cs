/*******************************************************************
 * FileName: CanvasAdjustor.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Framework {
    namespace Middleware {
        public class CanvasAdjustor {

            public CanvasAdjustor() { }

            public void Adjusting() {
                float standard_width = 1024f;        //初始宽度
                float standard_height = 640f;       //初始高度             
                float adjustor = 0f;         //屏幕矫正比例
                                             //获取设备宽高
                float device_width = Screen.width;      //当前设备宽度
                float device_height = Screen.height;   //当前设备高度
                //计算宽高比例
                float standard_aspect = standard_width / standard_height;
                float device_aspect = device_width / device_height;

                if (device_aspect < standard_aspect) {    //计算矫正比例
                    adjustor = standard_aspect / device_aspect;
                } // end if

                CanvasScaler canvasScalerTemp = CanvasManager.MainCanvasTrans.GetComponent<CanvasScaler>();

                if (adjustor == 0) {
                    canvasScalerTemp.matchWidthOrHeight = 1;
                } else {
                    canvasScalerTemp.matchWidthOrHeight = 0;
                } // end if
            } // end Adjusting
        } // end class CanvasAdjustor 
    } // end namespace Middleware
} // end namespace Framework