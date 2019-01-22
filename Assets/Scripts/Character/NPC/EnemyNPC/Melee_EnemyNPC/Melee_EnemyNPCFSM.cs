/*******************************************************************
 * FileName: Melee_EnemyNPCFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Melee_EnemyNPCFSM : CharacterFSM {

                public Melee_EnemyNPCFSM(ICharacter character) {
                    AddState(new EnemyNPCIdle(character));
                    AddState(new EnemyNPCWalk(character));
                    AddState(new NPCChase(character));
                    AddState(new Melee_NPCAttack_1(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end Melee_EnemyNPCFSM          
            } // end class Melee_EnemyNPCFSM
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 