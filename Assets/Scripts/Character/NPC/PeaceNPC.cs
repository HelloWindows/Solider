/*******************************************************************
 * FileName: PeaceNPC.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace NPC {
            public class PeaceNPC : Character {
                public PeaceNPC(string id, GameObject gameObject) : base(id, gameObject) {
                    m_fsm = new CharacterFSM();
                } // end PeaceNPC
            } // end class PeaceNPC 
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider