/*******************************************************************
 * FileName: UISettingPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UISettingPanel : MonoBehaviour {

		// Use this for initialization
		private void Start () {
            transform.Find("ExitBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickExitBtn(); });
            transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });       
            transform.Find("MusicSlider").GetComponent<Slider>().onValueChanged.AddListener(delegate (float value) { OnMusicSliderChange(value); });
            transform.Find("SoundSlider").GetComponent<Slider>().onValueChanged.AddListener(delegate (float value) { OnSoundSliderChange(value); });
            transform.Find("GameQuality/NormalToggle").GetComponent<Toggle>().onValueChanged.AddListener(delegate (bool isOn) { OnToggleNormal(isOn); });
            transform.Find("GameQuality/GoodToggle").GetComponent<Toggle>().onValueChanged.AddListener(delegate (bool isOn) { OnToggleGood(isOn); });
        } // end Start

        void OnMusicSliderChange(float value) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnMusicSliderChange Value: " + value);
#endif
        } // end OnMusicSliderChange

        void OnSoundSliderChange(float value) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnSoundSliderChange Value: " + value);
#endif
        } // end OnMusicSliderChange

        private void OnToggleNormal(bool isOn) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnToggleNormal Bool: " + isOn);
#endif
        } // end OnToggleEquipment

        private void OnToggleGood(bool isOn) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnToggleGood Bool: " + isOn);
#endif
        } // end OnToggleEquipment

        private void OnClickCloseBtn() {

            if (null == gameObject) return;
            //end if
            Destroy(gameObject);
        } // end OnClickInfoBtn

        private void OnClickExitBtn() {
            Application.Quit();
        } // end OnClickExitBtn
    } // end class UISettingPanel 
} // end namespace Solider