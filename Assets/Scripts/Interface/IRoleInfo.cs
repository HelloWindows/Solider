/*******************************************************************
 * FileName: IRoleInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model.Data;

namespace Solider {
    namespace Interface {
        public interface IRoleInfo {
            /// <summary>
            /// 是否存活
            /// </summary>
            /// <returns> 是否存活 </returns>
            bool IsLive { get; }
            /// <summary>
            /// 自愈
            /// </summary>
            void SelfHealing();
            /// <summary>
            /// 获取角色穿戴接口
            /// </summary>
            /// <returns> 角色穿戴接口 </returns>
            IWearInfo GetWearInfo();
            /// <summary>
            /// 根据类型获取背包接口
            /// </summary>
            /// <param name="type"></param>
            /// <returns> 背包接口 </returns>
            IPack GetItemPack(string type);
            /// <summary>
            /// 获取角色属性数据
            /// </summary>
            /// <returns> 属性数据 </returns>
            AttributeData GetAttributeData();
            /// <summary>
            /// 获取物品
            /// </summary>
            /// <param name="id"> 物品id </param>
            /// <param name="count"> 物品数量 </param>
            void PackItem(string id, int count);
        } // end class IRoleInfo
    } // end namespace Interface 
} // end namespace Solider 
