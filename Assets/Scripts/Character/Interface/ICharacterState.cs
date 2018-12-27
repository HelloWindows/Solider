/*******************************************************************
 * FileName: ICharacterState.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterState {
                /// <summary>
                /// id
                /// </summary>
                string id { get; }
                /// <summary>
                /// 状态层
                /// </summary>
                int layer { get; }
                /// <summary>
                /// 进入
                /// </summary>
                void DoBeforeEntering();
                /// <summary>
                /// 检测
                /// </summary>
                void Reason();
                /// <summary>
                /// 行为
                /// </summary>
                void Act();
                /// <summary>
                /// 离开
                /// </summary>
                void DoBeforeLeaving();
            } // end class ICharacterState
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 
