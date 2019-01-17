/*******************************************************************
 * FileName: IRealData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface IRealData {
                /// <summary>
                /// 恢复 hp
                /// </summary>
                int HP { get; }
                /// <summary>
                /// 恢复 mp
                /// </summary>
                int MP { get; }
                /// <summary>
                /// 已损失 hp 百分率
                /// </summary>
                float HPR { get; }
                /// <summary>
                /// 已损失 mp 百分率
                /// </summary>
                float MPR { get; }
                /// <summary>
                /// 最大 hp 百分率
                /// </summary>
                float XHR { get; }
                /// <summary>
                /// 最大 mp 百分率
                /// </summary>
                float XMR { get; }
                /// <summary>
                /// 是否命中
                /// </summary>
                bool ismiss { get; }
            } // end class IRealData
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 
