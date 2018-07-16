/*******************************************************************
 * FileName: IWearEquip.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;
using System.Collections.Generic;

namespace Solider {
    namespace Interface {
        public interface IWearInfo {
            /// <summary>
            /// 卸载装备
            /// </summary>
            /// <param name="type"> 装备类型 </param>
            void TakeOffEquip(string type);
            /// <summary>
            /// 获取穿戴装备id字典
            /// </summary>
            /// <returns> 装备id字典 </returns>
            Dictionary<string, string> GetWearEquip();
            /// <summary>
            /// 根据装备类型获取装备信息
            /// </summary>
            /// <param name="type"> 装备类型 </param>
            /// <returns> 装备信息 </returns>
            EquipInfo GetEquipInfo(string type);
        } // end interface IWearInfo
    } // end namespace Interface
} // end namespace Solider 
