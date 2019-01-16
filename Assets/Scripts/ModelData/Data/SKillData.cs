/*******************************************************************
 * FileName: SKillData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.ModelData.Interface;

namespace Solider {
    namespace ModelData {
        namespace Data {
            public class SKillData : ISKillData {
                public int ATK { get; private set; }
                public int MGK { get; private set; }
                public float ATKR { get; private set; }
                public float MGKR { get; private set; }
                public float DEFR { get; private set; }
                public float RGSR { get; private set; }
            } // end class SKillData
        } // end namespace Data
    } // end namespace ModelData
} // end namespace Solider 
