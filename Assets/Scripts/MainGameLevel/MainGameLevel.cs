/*******************************************************************
 * FileName: MainGameLevel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using Solider.Manager;
using UnityEngine;

namespace Solider {
	public class MainGameLevel : MonoBehaviour {
        private float timer;

		// Use this for initialization
		void Start () {
            timer = 0;
            ObjectTool.InstantiateGo("MainPanelUI", "MainGameLevel/UI/MainPanelUI", CanvasManager.MainCanvasTrans).AddComponent<UIMainPanel>();
            ObjectTool.InstantiateGo("TownPanelUI", "MainGameLevel/UI/TownPanelUI", CanvasManager.MainCanvasTrans).AddComponent<UITownPanel>();

            //if (null == gameObject) return;
            //Destroy(gameObject);
        } // end Start

        private void Update() {
            timer += Time.deltaTime;
            if (timer > 1) {
                timer = 0;
                RoleManager.info.SelfHealing();
            } // end if
        } // end Update
    } // end class MainGameLevel 
} // end namespace Solider