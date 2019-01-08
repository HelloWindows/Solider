/*******************************************************************
 * FileName: PeaceNPCFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class PeaceNPCFSM : CharacterFSM {

                public PeaceNPCFSM(ICharacter character) {
                    AddState(new PeaceNPCIdle(character));
                    AddState(new PeaceNPCWalk(character));
                    AddState(new NPCEscape(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end SwordmanFSM          
            } // end class PeaceNPCFSM
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 