/*******************************************************************
 * FileName: IPackInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Model {
        namespace Interface {
            public interface IPackInfo {
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
                /// 获取物品
                /// </summary>
                /// <param name="id"> 物品id </param>
                /// <param name="count"> 物品数量 </param>
                void PackItem(string id, int count);
            } // end class IPackInfo
        } // end namespace Interface 
    } // end namespace Model
} // end namespace Solider 
