/*******************************************************************
 * FileName: HPBar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using UnityEngine;

namespace Solider {
    namespace Widget {
        public class HPBar : MonoBehaviour {
            private SpriteRenderer sprite;

            private void Awake() {
                sprite = GetComponent<SpriteRenderer>();
                sprite.material = new Material(Shader.Find("Custom/Sprites/SliderSprites"));
            } // end Start

            // Update is called once per frame
            void Update() {
                transform.rotation = SceneManager.mainCamera.camera.transform.rotation;
            } // end Update

            public void SetFillAmount(float amount) {
                sprite.material.SetFloat("_Fill", amount);
            } // end SetFillAmount

            public void Recycling() {
                InstanceMgr.GetObjectManager().Recycling("hp_bar", gameObject);
            } // end Recycling
        } // end class InfoUI 
    } // end namespace Widget
} // end namespace Solider