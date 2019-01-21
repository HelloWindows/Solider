/*******************************************************************
 * FileName: Melee_NeutralNPCFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Melee_NeutralNPCFSM : CharacterFSM {

                public Melee_NeutralNPCFSM(ICharacter character) {
                    AddState(new NeutralNPCIdle(character));
                    AddState(new NeutralNPCWalk(character));
                    AddState(new NPCChase(character));
                    AddState(new Melee_NPCAttack_1(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end Melee_NeutralNPCFSM          
            } // end class Melee_NeutralNPCFSM
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 