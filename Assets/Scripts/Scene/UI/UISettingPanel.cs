﻿/*******************************************************************
 * FileName: UISettingPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.Manager;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UISettingPanel : IFSMState {
                public string id { get { return "setting_panel_ui"; } }

                private RectTransform rectTransform;
                private GameObject gameObject;

                public UISettingPanel() {
                } // end UISettingPanel

                void OnMusicSliderChange(float value) {
                    GameManager.gameSetting.SetMusicValue(value);
                    ConsoleTool.SetConsole("OnMusicSliderChange Value: " + value);
                } // end OnMusicSliderChange

                void OnSoundSliderChange(float value) {
                    GameManager.gameSetting.SetSoundValue(value);
                    ConsoleTool.SetConsole("OnSoundSliderChange Value: " + value);
                } // end OnMusicSliderChange

                private void OnToggleNormal(bool isOn) {
                    if (!isOn) return;
                    // end if
                    GameManager.gameSetting.SetQuality("Simple");
                    ConsoleTool.SetConsole("OnToggleNormal Bool: " + isOn);
                } // end OnToggleEquipment

                private void OnToggleGood(bool isOn) {
                    if (!isOn) return;
                    // end if
                    GameManager.gameSetting.SetQuality("Good");
                    ConsoleTool.SetConsole("OnToggleGood Bool: " + isOn);
                } // end OnToggleEquipment

                private void OnClickCloseBtn() {
                    SceneManager.uiPanelFMS.TransitionPrev();
                } // end OnClickInfoBtn

                private void OnClickExitBtn() {
                    Application.Quit();
                } // end OnClickExitBtn

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("SettingPanelUI", ResourcesTool.LoadPrefabUI(id), 
                        SceneManager.mainCanvas.rectTransform);
                    rectTransform = gameObject.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = SceneManager.mainCanvas.sizeDelta;
                    rectTransform.Find("ExitBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickExitBtn(); });
                    rectTransform.Find("CloseBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickCloseBtn(); }, "ui_close");
                    Slider musicSlider = rectTransform.Find("MusicSlider").GetComponent<Slider>();
                    musicSlider.minValue = 0f;
                    musicSlider.maxValue = 1f;
                    musicSlider.value = GameManager.gameSetting.musicValue;
                    musicSlider.onValueChanged.AddListener(delegate (float value) { OnMusicSliderChange(value); });
                    Slider soundSlider = rectTransform.Find("SoundSlider").GetComponent<Slider>();
                    soundSlider.minValue = 0f;
                    soundSlider.maxValue = 1f;
                    soundSlider.value = GameManager.gameSetting.soundValue;
                    soundSlider.onValueChanged.AddListener(delegate (float value) { OnSoundSliderChange(value); });
                    Toggle simple = rectTransform.Find("GameQuality/NormalToggle").GetComponent<Toggle>();
                    simple.onValueChanged.AddListener(delegate (bool isOn) { OnToggleNormal(isOn); });
                    Toggle good = rectTransform.Find("GameQuality/GoodToggle").GetComponent<Toggle>();
                    good.onValueChanged.AddListener(delegate (bool isOn) { OnToggleGood(isOn); });
                    if (GameManager.gameSetting.currentQuality == "Good") {
                        good.isOn = true;
                    } // end if
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason 

                public void Act() {
                } // end Act
            } // end class UISettingPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider