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
                public const int GRID_COUNT = 25;

                public static string[] EquipTypeList { get { return equipTypeList; } }
                private static readonly string[] equipTypeList = { WEAPON, NECKLACE, RING, WING, ARMOR, PANTS, SHOES };
                /// <summary>
                /// 狂战士
                /// </summary>
                public const string SWORDMAN = "swordman";
                /// <summary>
                /// 弓箭手
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
                /// 项链
                /// </summary>
                public const string NECKLACE = "necklace";
                /// <summary>
                /// 戒指
                /// </summary>
                public const string RING = "ring";
                /// <summary>
                /// 翅膀
                /// </summary>
                public const string WING = "wing";
                /// <summary>
                /// 盔甲
                /// </summary>
                public const string ARMOR = "armor";
                /// <summary>
                /// 裤子
                /// </summary>
                public const string PANTS = "pants"; 
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
                /// <summary>
                /// 制作图
                /// </summary>
                public const string PRINT = "print";
            } // end class ConstConfig 
        } // end namespace Const 
    } // end namespace Config
} // end namespace Custom