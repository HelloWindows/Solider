/*******************************************************************
 * FileName: ISkillTimer.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;

namespace Solider {
    namespace Model {
        namespace Interface {
            public interface ISkillModle : ITimer {
                int layer { get; }
                ISkillInfo info { get; }
            } // end interface ISkillModle 
        } // end namespace Interface
    } // end namespace Model
} // end namespace Solider