/*******************************************************************
 * FileName: IPack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;

namespace Solider {
    namespace Interface {
        public interface IPack {
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
