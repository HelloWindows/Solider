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
            private Transform follow;
            private SpriteRenderer sprite;

            private void Start() {
                sprite = GetComponent<SpriteRenderer>();
                sprite.material = new Material(Shader.Find("Custom/Sprites/SliderSprites"));
            } // end Start

            public void SetFollow(Transform follow) {
                this.follow = follow;
            } // end SetFollow

            // Update is called once per frame
            void Update() {
                if (null == follow) {
                    Recycling();
                    return;
                } // end if
                transform.position = follow.position;
                transform.rotation = SceneManager.mainCamera.camera.transform.rotation;
            } // end Update

            public void Recycling() {
                InstanceMgr.GetObjectManager().Recycling("hp_bar", gameObject);
            } // end Recycling
        } // end class InfoUI 
    } // end namespace Widget
} // end namespace Solider