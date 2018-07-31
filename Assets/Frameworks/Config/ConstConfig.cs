/*******************************************************************
 * FileName: ConstConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Framework {
    namespace Config {
        namespace Const {
            public static class ConstConfig {
                public const float STANDARD_WIDTH = 1024f;
                public const float STANDARD_HEIGHT = 640f;

                public const int GRID_COUNT = 25;
                public static readonly string[] packTypeList = { "equip", "consume", "stuff" };
                /// <summary>
                /// 战士
                /// </summary>
                public const string SWORDMAN = "swordman";
                /// <summary>
                /// 射手
                /// </summary>
                public const string ARCHER = "archer";
                /// <summary>
                /// 魔法师
                /// </summary>
                public const string MAGICIAN = "magician"; 
                /// <summary>
                /// 全部职业
                /// </summary>
                public const string ALLROLE = "all";
                /// <summary>
                /// 武器
                /// </summary>
                public const string WEAPON = "weapon";
                /// <summary>
                /// 盔甲
                /// </summary>
                public const string ARMOE = "armor";
                /// <summary>
                /// 鞋子
                /// </summary>
                public const string SHOES = "shoes";
                /// <summary>
                /// 装备
                /// </summary>
                public const string EQUIP = "equip";
                /// <summary>
                /// 消耗品
                /// </summary>
                public const string CONSUME = "consume";
                /// <summary>
                /// 材料
                /// </summary>
                public const string STUFF = "stuff";
            } // end class ConstConfig 
        } // end namespace Const 
    } // end namespace Config
} // end namespace Custom