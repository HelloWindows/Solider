﻿/*******************************************************************
 * FileName: ConstConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework {
    namespace Config {
        public static class ConstConfig {
            public const int GRID_COUNT = 25;
            public static readonly string[] packTypeList = { "equip", "consume", "stuff" };
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
    } // end namespace Config
} // end namespace Custom