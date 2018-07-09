/*******************************************************************
 * FileName: PlayerDisplayRaw.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
	public class PlayerDisplayRaw : MonoBehaviour, IDragHandler, IBeginDragHandler {

        private float lastX;
        private Vector3 rotSpeed;
        private Transform displayTrans;

        public void OnBeginDrag(PointerEventData data) {
            lastX = data.position.x;
        } // end OnBeginDrag

        public void OnDrag(PointerEventData data) {

            if (null == displayTrans) return;
            // end if
            displayTrans.localEulerAngles -= rotSpeed * (data.position.x - lastX);
            lastX = data.position.x;
        } // end OnDrag

        // Use this for initialization
        void Start () {
            rotSpeed = new Vector3(0, 1, 0);
            RenderTexture texture = new RenderTexture(320, 420, 24, RenderTextureFormat.ARGB32);
            texture.anisoLevel = 0;
            texture.antiAliasing = 4;
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Bilinear;
            gameObject.GetComponent<RawImage>().texture = texture;

            Camera camera = ObjectTool.InstantiateEmptyGo("PlayerDisplayCamera", transform, new Vector3(0, 0, 1)).AddComponent<Camera>();
            camera.clearFlags = CameraClearFlags.Color;
            camera.backgroundColor = Color.gray;
            camera.cullingMask = 1 << 2;
            camera.fieldOfView = 50;
            camera.targetTexture = texture;
            displayTrans = ObjectTool.InstantiateGo("PlayerDisplay", "Players/PlayerDisplay", camera.transform, new Vector3(0, -1.2f, 4), Vector3.zero, Vector3.one).transform;
        } // end Start
    } // end class PlayerDisplayRaw 
} // end namespace Solider