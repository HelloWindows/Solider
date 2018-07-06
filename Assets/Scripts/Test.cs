/*******************************************************************
 * FileName: Test.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Custom {
	public class Test : MonoBehaviour, IPointerClickHandler {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Click");
        }

        // Use this for initialization
        void Start () {
			
		} // end Start
	
		// Update is called once per frame
		void Update () {
			
		} // end Update
	} // end class Test 
} // end namespace Custom