/*******************************************************************
 * FileName: IAttackData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface IAttackData {
                string id { get; }
                int ATK { get; }
                int MGK { get; }
                float HIT { get; } // 命中率
                bool iscrit { get; } // 暴击
                bool ismiss { get; } // 失误
            } // end class IAttackData
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 
