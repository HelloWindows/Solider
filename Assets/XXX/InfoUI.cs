/*******************************************************************
 * FileName: InfoUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Custom {
	public class InfoUI : MonoBehaviour {

        private SpriteRenderer sprite;
        private TextMesh text;

        private void Start() {
            sprite = GetComponentInChildren<SpriteRenderer>();
            text = GetComponentInChildren<TextMesh>();
            text.text = "123";
        } // end Start


        // Update is called once per frame
        void Update () {
            transform.localRotation = Camera.main.transform.rotation;
            if (Input.GetKeyDown(KeyCode.Space)) {
                sprite.material.SetFloat("_Fill", Random.Range(0f, 1f));
            } // end if
		} // end Update
	} // end class InfoUI 
} // end namespace Custom