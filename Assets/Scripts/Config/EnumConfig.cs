/*******************************************************************
 * FileName: EnumConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Character {
        namespace FSM {
            public enum StateLayer : int {
                /// <summary>
                /// 默认层
                /// </summary>
                Default = 0,
                /// <summary>
                /// 技能层
                /// </summary>
                Skill = 1,
                /// <summary>
                /// 强制层
                /// </summary>
                Force = 2,
                /// <summary>
                /// 最高层
                /// </summary>
                Highest = 100
            } // end enum StateLayer
        } // end namespace FSM

        namespace NPC {
            public enum NPCType : int {
                Null = 0,
                /// <summary>
                /// 和平
                /// </summary>
                Peace = 1,
                /// <summary>
                /// 中立—近战
                /// </summary>
                Melee_Neutral = 2,
                /// <summary>
                /// 中立—远程
                /// </summary>
                Range_Neutral = 3,
            } // end enum NPCType
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider
