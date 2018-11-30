/*******************************************************************
 * FileName: GameManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;
using Solider.Model.Interface;

namespace Solider {
    namespace Manager {
        public enum GameState : int {
            /// <summary>
            /// 初始化
            /// </summary>
            INITIALIZATION = 0,
            /// <summary>
            /// 运行
            /// </summary>
            PLAY = 1,
            /// <summary>
            /// 暂停
            /// </summary>
            PAUSE = 2,
            /// <summary>
            /// 切换场景
            /// </summary>
            SWITCH = 3,
            /// <summary>
            /// 过场动画
            /// </summary>
            INTERLUDE = 4,
            /// <summary>
            /// 结束
            /// </summary>
            OVER = 5
        } // end enum GameState

        public static class GameManager {
            public static GameState state { get; private set; }
            public static IPlayerInfo playerInfo { get; private set; }
            public static IGameSetting gameSetting { get; private set; }

            public static void Init() {
                if (null == playerInfo) {
                    playerInfo = new PlayerInfo();
                } // end if
                if (null == gameSetting) {
                    gameSetting = new GameSetting();
                } // end if
            } // end Init

            public static void SetGameState(GameState state) {
                GameManager.state = state;
            } // end SetGameState
        } // end class GameManager 
    } // end namespace Manager
} // end namespace Custom