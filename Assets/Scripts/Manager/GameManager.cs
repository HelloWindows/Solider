/*******************************************************************
 * FileName: GameManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;
using Solider.Interface;

namespace Solider {
    namespace Manager {
        public class GameManager {
            public static IGameSetting gameSetting { get; private set; }
            public static void Init() {
                if (null == gameSetting) {
                    gameSetting = new GameSetting();
                } // end if
            } // end Init
        } // end class GameManager 
    } // end namespace Manager
} // end namespace Custom