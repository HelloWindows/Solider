/*******************************************************************
 * FileName: HP_Bar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using UnityEngine;

namespace Solider {
    namespace Widget {
        public class HP_Bar : MonoBehaviour {
            public const string poolName = "hp_bar";
            private MeshRenderer meshRenderer;

            private void Awake() {
                meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.material = new Material(Shader.Find("Custom/Color/SliderBar"));
                meshRenderer.material.SetColor("_Color", Color.red);
            } // end Start

            // Update is called once per frame
            void Update() {
                transform.rotation = SceneManager.mainCamera.camera.transform.rotation;
            } // end Update

            public void SetFillAmount(float amount) {
                meshRenderer.material.SetFloat("_Fill", amount);
            } // end SetFillAmount

            public void Recycling() {
                InstanceMgr.GetObjectManager().Recycling(poolName, gameObject);
            } // end Recycling
        } // end class HP_Bar 
    } // end namespace Widget
} // end namespace Solider