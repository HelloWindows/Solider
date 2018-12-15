/*******************************************************************
 * FileName: ISkillTimer.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;

namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface ISkillTimer : ITimer{
                ISkillInfo info { get; }
            } // end interface ITimer 
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider