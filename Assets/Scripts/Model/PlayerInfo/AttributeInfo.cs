/*******************************************************************
 * FileName: AttributeInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Model {
        public class AttributeInfo {
            public int HP { get; private set; } 
            public int MP { get; private set; }
            public int min_ATK { get; private set; }
            public int max_ATK { get; private set; }
            public int min_MGK { get; private set; }
            public int max_MGK { get; private set; }
            public int DEF { get; private set; }
            public int RGS { get; private set; }
            public float CRT { get; private set; }

            public void SetHP(int hp) { HP = hp; }
            public void SetMinATk(int atk) { min_ATK = atk; }
            public void SetMaxATK(int atk) { max_ATK = atk; }

            public static AttributeInfo operator +(AttributeInfo info, AttackInfo att) {
                int atk = att.ATK - info.DEF;
                if (atk < 0) atk = 0;
                int mgk = att.MGK - info.RGS;
                if (mgk < 0) mgk = 0;
                info.HP -= atk + mgk;
                return info;
            } // end operator +
        } // end class AttributeInfo
    } // end namespace Model
} // end namespace Solider 
