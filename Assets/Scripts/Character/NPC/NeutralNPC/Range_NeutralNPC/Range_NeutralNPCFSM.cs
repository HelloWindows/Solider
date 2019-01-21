/*******************************************************************
 * FileName: Range_NeutralNPCFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Range_NeutralNPCFSM : CharacterFSM {

                public Range_NeutralNPCFSM(ICharacter character) {
                    AddState(new NeutralNPCIdle(character));
                    AddState(new NeutralNPCWalk(character));
                    AddState(new NPCChase(character));
                    AddState(new Range_NPCAttack_1(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end Range_NeutralNPCFSM          
            } // end class Range_NeutralNPCFSM
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 