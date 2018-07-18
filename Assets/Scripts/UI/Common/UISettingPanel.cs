/*******************************************************************
 * FileName: UISettingPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Manager;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Common {
            public class UISettingPanel : MonoBehaviour {
                // Use this for initialization
                private void Start() {
                    transform.Find("ExitBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickExitBtn(); });
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
                    Slider musicSlider = transform.Find("MusicSlider").GetComponent<Slider>();
                    musicSlider.minValue = 0f;
                    musicSlider.maxValue = 1f;
                    musicSlider.value = GameManager.gameSetting.musicValue;
                    musicSlider.onValueChanged.AddListener(delegate (float value) { OnMusicSliderChange(value); });
                    Slider soundSlider = transform.Find("SoundSlider").GetComponent<Slider>();
                    soundSlider.minValue = 0f;
                    soundSlider.maxValue = 1f;
                    soundSlider.value = GameManager.gameSetting.soundValue;
                    soundSlider.onValueChanged.AddListener(delegate (float value) { OnSoundSliderChange(value); });
                    Toggle simple = transform.Find("GameQuality/NormalToggle").GetComponent<Toggle>();
                    simple.onValueChanged.AddListener(delegate (bool isOn) { OnToggleNormal(isOn); });
                    Toggle good = transform.Find("GameQuality/GoodToggle").GetComponent<Toggle>();
                    good.onValueChanged.AddListener(delegate (bool isOn) { OnToggleGood(isOn); });
                    if (GameManager.gameSetting.currentQuality == "Good") {
                        good.isOn = true;
                    } // end if
                } // end Start

                void OnMusicSliderChange(float value) {
                    GameManager.gameSetting.SetMusicValue(value);
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnMusicSliderChange Value: " + value);
#endif
                } // end OnMusicSliderChange

                void OnSoundSliderChange(float value) {
                    GameManager.gameSetting.SetSoundValue(value);
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnSoundSliderChange Value: " + value);
#endif
                } // end OnMusicSliderChange

                private void OnToggleNormal(bool isOn) {
                    if (!isOn) return;
                    // end if
                    GameManager.gameSetting.SetQuality("Simple");
#if __MY_DEBUG__
                    ConsoleTool.SetConsole("OnToggleNormal Bool: " + isOn);
#endif
                } // end OnToggleEquipment

                private void OnToggleGood(bool isOn) {
                    if (!isOn) return;
                    // end if
                    GameManager.gameSetting.SetQuality("Good");
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
        } // end namespace Common
    } // end namespace UI 
} // end namespace Solider