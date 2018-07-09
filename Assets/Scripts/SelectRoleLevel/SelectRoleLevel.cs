/*******************************************************************
 * FileName: SelectUser.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using UnityEngine;

namespace Solider {
	public class SelectRoleLevel : MonoBehaviour {

        private void Start() {
            ObjectTool.InstantiateGo("SelectRolePanelUI", "SelectRoleLevel/UI/SelectRolePanelUI", CanvasManager.MainCanvasTrans).AddComponent<UISelectRolePanel>();
       
            if (null == gameObject) return;
            Destroy(gameObject);
        } // end Start
    } // end class SelectRoleLevel
} // end namespace Solider 
