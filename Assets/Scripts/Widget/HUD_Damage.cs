/*******************************************************************
 * FileName: HUD_Damage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Widget {
        public class HUD_Damage : MonoBehaviour {

            private Text m_text;

            private void Awake() {
                m_text = GetComponentInChildren<Text>();
            } // end Awake

            private void OnEnable() {
                StartCoroutine(PlayAnimation());
            } // end OnEnable

            public void SetNumber(int value) {
                value = Mathf.Abs(value);
                m_text.text = value.ToString();
            } // end SetNumber

            IEnumerator PlayAnimation() {
                float smooth = 0f;
                m_text.rectTransform.localPosition = Vector3.zero;
                m_text.rectTransform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                WaitForEndOfFrame wait = new WaitForEndOfFrame();
                while (smooth < 1f) {
                    smooth += Time.deltaTime * 3f;
                    m_text.rectTransform.localScale = Mathf.Lerp(0f, 0.8f, smooth) * Vector3.one;
                    yield return wait;
                } // end while
                smooth = 0;
                Color col = new Color(1f, 1f, 1f, 1f);
                while (smooth < 1f) {
                    smooth += Time.deltaTime * 2f;
                    m_text.rectTransform.localPosition = Vector3.up * smooth * 30f;
                    col.a = 1f - smooth;
                    m_text.color = col;
                    yield return wait;
                } // end while
                Recycling();
            } // end PlayAnimation

            public void Recycling() {
                InstanceMgr.GetObjectManager().Recycling("hud_damage", gameObject);
            } // end Recycling
        } // end class HUD_Damage 
    } // end namespace Widget
} // end namespace Solider