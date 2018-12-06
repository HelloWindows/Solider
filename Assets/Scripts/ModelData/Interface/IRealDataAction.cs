/*******************************************************************
 * FileName: IRealDataAction.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface IRealDataAction {
                /// <summary>
                /// 设置为角色自我状态恢复的数据
                /// </summary>
                /// <param name="data"> 属性数据 </param>
                void SetSelfTreat(IAttributeData data);
            } // end class IRealDataAction
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 
