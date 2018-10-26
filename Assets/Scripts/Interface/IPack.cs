/*******************************************************************
 * FileName: IPack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;

namespace Solider {
    namespace Interface {
        public interface IPack {
            /// <summary>
            /// 背包是否已满
            /// </summary>
            bool IsFull { get; }
            /// <summary>
            /// 获取物品
            /// </summary>
            /// <param name="itemID"> 物品ID </param>
            /// <param name="count"> 物品数量 </param>
            void PackItem(string itemID, int count);
            /// <summary>
            /// 判断对应物品是否足够数量
            /// </summary>
            /// <param name="itemID"> 物品ID </param>
            /// <param name="count"> 预期数量 </param>
            /// <returns> 是否足够 </returns>
            bool EnoughWithIDAndCount(string itemID, int count);
            /// <summary>
            /// 使用对应格子的物品
            /// </summary>
            /// <param name="gid"> 格子id </param>
            void UseItemWithGid(int gid);
            /// <summary>
            /// 消耗对应的物品,使用之前请先调用 EnoughWithIDAndCount 去判断是否足够
            /// </summary>
            /// <param name="itemID"></param>
            void ExpendItemWithID(string itemID, int count);
            /// <summary>
            /// 获取对应格子的物品信息
            /// </summary>
            /// <param name="gid"> 格子id </param>
            /// <returns> 物品信息 </returns>
            ItemInfo GetItemInfoForGrid(int gid);
            /// <summary>
            /// 获取对应格子的物品数量
            /// </summary>
            /// <param name="gid"> 格子id </param>
            /// <returns> 物品数量 </returns>
            int GetCountForGrid(int gid);
            /// <summary>
            /// 获取背包中某物品的数量
            /// </summary>
            /// <param name="itemID"></param>
            /// <returns> 物品数量 </returns>
            int GetCountForID(string itemID);
            /// <summary>
            /// 置换两个格子的物品
            /// </summary>
            /// <param name="gid"> 格子 id </param>
            /// <param name="target"> 目标格子 id </param>
            void ExchangeGridInfoWithGid(int gid, int target);
            /// <summary>
            /// 背包排序
            /// </summary>
            void ArrangePack();
            /// <summary>
            /// 丢弃对应格子的物品
            /// </summary>
            /// <param name="gid"></param>
            /// <param name="count"></param>
            void DiscardItem(int gid, int count);
        } // end interface IPack
    } // end namespace Interface 
} // end namespace Custom 
