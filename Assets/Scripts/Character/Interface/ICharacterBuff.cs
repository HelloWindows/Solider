﻿/*******************************************************************
 * FileName: ICharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Icon;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterBuff {
                void InsertBuff(BuffInfo buffInfo);
                List<BuffInfo> GetBuffInfoList();
                List<float> GetScheduleList();
            } // end interface ICharacterBuff
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 
