/*******************************************************************
 * FileName: MainGameLevel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
	public class MainGameLevel : MonoBehaviour {

		// Use this for initialization
		void Start () {
            ObjectTool.InstantiateGo("MainPanelUI", "UI/MainPanelUI", CanvasManager.MainCanvasTrans).AddComponent<UIMainPanel>();
		} // end Start
	} // end class MainGameLevel 
} // end namespace Solider