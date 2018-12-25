/*******************************************************************
 * FileName: ICharacterCenter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using Solider.Character;

namespace Solider {
    namespace Character {
        public enum CenterEvent : int {
            NULL = 0,
            /// <summary>
            /// 更换了装备
            /// </summary>
            ReloadEquip = 1,
            /// <summary>
            /// 改变了 Buff
            /// </summary>
            BuffChange = 2
        } // end CenterEvent

        namespace Interface {
            public interface ICharacterCenter {
                /// <summary>
                /// 监听广播
                /// </summary>
                /// <param name="action"></param>
                void AddListener(Action<CenterEvent> action);
                /// <summary>
                /// 移除监听
                /// </summary>
                /// <param name="action"></param>
                void RemoveListener(Action<CenterEvent> action);
                /// <summary>
                /// 广播
                /// </summary>
                /// <param name="content"></param>
                void Broadcast(CenterEvent content);
            } // end interface ICharacterCenter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 