/*******************************************************************
 * FileName: GameSetting.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;
using Solider.Model.Interface;
using Framework.Tools;

namespace Solider {
    namespace Model {
        [Serializable]
        public class GameSetting : IGameSetting {
            public float musicValue { get; private set; }
            public float soundValue { get; private set; }
            public string currentQuality { get; private set; }
            private string path;

            public GameSetting() {
                currentQuality = "Simple";
                path = PlatformTool.GetPersistentDataPath("GameSetting.bin");
                GameSetting setting = SerializeTool.GetDataWithPath<GameSetting>(path);
                if (setting == null) {
                    musicValue = 0.5f;
                    soundValue = 0.5f;
                    return;
                } // end if 
                musicValue = setting.musicValue;
                soundValue = setting.soundValue;
                SetQuality(setting.currentQuality);
            } // end GameSetting

            public void SetMusicValue(float value) {
                musicValue = Mathf.Clamp01(value);
                SerializeTool.DataSaveWithPath(this, path);
            } // end SetMusicValue

            public void SetSoundValue(float value) {
                soundValue = Mathf.Clamp01(value);
                SerializeTool.DataSaveWithPath(this, path);
            } // end SetSoundValue
          
            public void SetQuality(string name) {
                if (currentQuality == name) return;
                // end if
                string[] names = QualitySettings.names;
                for (int i = 0; i < names.Length; i++) {
                    if (name == names[i]) {
                        currentQuality = name;
                        QualitySettings.SetQualityLevel(i, true);
                        SerializeTool.DataSaveWithPath(this, path);
                        return;
                    } // end if
                } // end for
            } // end SetQuality
        } // end class GameSetting 
    } // end namespace Model
} // end namespace Solider