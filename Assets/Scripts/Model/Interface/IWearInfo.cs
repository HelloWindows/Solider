/*******************************************************************
 * FileName: IWearEquip.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;

namespace Solider {
    namespace Model {
        namespace Interface {
            public interface IWearInfo {
                /// <summary>
                /// 卸载装备
                /// </summary>
                /// <param name="type"> 装备类型 </param>
                void TakeOffEquip(string type);
                /// <summary>
                /// 根据装备类型获取装备信息
                /// </summary>
                /// <param name="type"> 装备类型 </param>
                /// <returns> 装备信息 </returns>
                IEquipInfo GetEquipInfo(string type);
            } // end interface IWearInfo
        } // end namespace Interface
    } // end namespace Model
} // end namespace Solider 
