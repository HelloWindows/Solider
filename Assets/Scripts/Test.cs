/*******************************************************************
 * FileName: Test.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Solider.Config;

namespace Custom {
	public class Test : MonoBehaviour {
        private void Start() {
            string path = "";
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IPHONE
            path = Application.streamingAssetsPath + "/config/res_config.unity3d";
#elif UNITY_ANDROID
            path = Application.dataPath + "!assets" + "/config/res_config.unity3d";	     
#endif
            AssetBundle assetbundle = AssetBundle.LoadFromFile(path);
            string jsonStr = assetbundle.LoadAsset<TextAsset>("assets/config/equipment_res_config.json").text;
            JsonData data = JsonMapper.ToObject(jsonStr);
            JsonData list = data["itemlist"];
            Dictionary<string, EquipInfo> dict = new Dictionary<string, EquipInfo>();

            for (int i = 0; i < list.Count; i++) {
                EquipInfo info = new EquipInfo();
                info.SetID((string)list[i]["id"]);
                info.SetName((string)list[i]["name"]);
                info.SetRole((string)list[i]["role"]);
                info.SetSpritepath((string)list[i]["spritepath"]);
                info.SetIntro((string)list[i]["intro"]);
                JsonData property = list[i]["property"];
                info.SetAttmin((int)property["attmin"]);
                info.SetAttmax((int)property["attmax"]);
                info.SetDef((int)property["def"]);
                info.SetAttspeed((float)property["attspeed"]);
                info.SetMovspeed((float)property["movspeed"]);
                info.SetCrit((float)property["crit"]);
                info.SetClip((float)property["clip"]);
                dict.Add((string)list[i]["id"], info);
            } // end for

            foreach (KeyValuePair<string, EquipInfo> pair in dict) {
                Debug.Log(pair.Key + "  " + pair.Value);
            } // end foreach
        } // end Start
    } // end class Test 
} // end namespace Custom