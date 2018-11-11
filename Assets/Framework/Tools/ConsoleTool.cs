/*******************************************************************
 * FileName: ConsoleTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Tools;
using System.Collections;
using UnityEngine;

public class ConsoleTool : MonoBehaviour {
#if __MY_DEBUG__
    private static ConsoleTool instance;
    private static Hashtable infoTable;
    private static string console;
    private static string errorMsg;
    private GUIStyle fontStyle;

    private static ConsoleTool GetInstance() {

        if (null == instance) {
            ObjectTool.InstantiateEmptyGo("ConsoleTool").AddComponent<ConsoleTool>();
            DontDestroyOnLoad(instance.gameObject);
        } // end if
        return instance;
    } // end GetInstance

    private void Awake() {
        if (null != instance) {
            enabled = false;
            Debug.LogError("[ERROR] Have tow ConsoleTool!");
            return;
        } // end if
        instance = this;
        infoTable = new Hashtable();
        fontStyle = new GUIStyle();
        fontStyle.normal.textColor = new Color(1, 1, 1);   //设置字体颜色  
        fontStyle.fontSize = 14;       //字体大小 
        fontStyle.wordWrap = true;
        AddInfoTable("FPS");
    } // end Awake

    private void Update() {
        SetInfo("FPS", (1f / Time.deltaTime).ToString("f0"));
    } // end Update
#endif

    public static void AddInfoTable(string key) {
#if __MY_DEBUG__
        GetInstance();
        if (!infoTable.ContainsKey(key)) {
            infoTable.Add(key, "");
            return;
        } // end if
        Debug.Log("InfoTable " + key + "is exist!");
#endif
    } // end AddInfoTable

    public static void SetInfo(string key, string info) {
#if __MY_DEBUG__
        GetInstance();
        if (!infoTable.ContainsKey(key) || null == info) {
            Debug.Log("InfoTable " + key + "is don't exist!");
            return;
        } // end if
        infoTable[key] = info;
#endif
    } // end SetInfo

    public static void SetConsole(string msg) {
#if __MY_DEBUG__
        GetInstance();
        console = msg;
#endif
    } // end SetConsole

    public static void SetError(string msg) {
#if __MY_DEBUG__
        GetInstance();
        errorMsg = msg;
#endif
    } // end SetError

#if __MY_DEBUG__
    private void OnGUI() {
        string info = "";
        fontStyle.fontSize = (int)(Screen.width / GameConfig.STANDARD_WIDTH * 20);

        foreach (DictionaryEntry de in infoTable) {
            info += de.Key + ": " + de.Value + '\n';
        } // end foreach
        info += console + '\n';
        info += "[Error] " + errorMsg;
        GUI.Label(new Rect(5f, 5f, Screen.width, Screen.height), info, fontStyle);
    } // end OnGUI
#endif
} // end class ConsoleTool 