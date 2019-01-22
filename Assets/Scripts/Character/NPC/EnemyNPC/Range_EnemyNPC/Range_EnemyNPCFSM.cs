/*******************************************************************
 * FileName: Range_EnemyNPCFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Range_EnemyNPCFSM : CharacterFSM {

                public Range_EnemyNPCFSM(ICharacter character) {
                    AddState(new EnemyNPCIdle(character));
                    AddState(new EnemyNPCWalk(character));
                    AddState(new NPCChase(character));
                    AddState(new Range_NPCAttack_1(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end Range_EnemyNPCFSM          
            } // end class Range_EnemyNPCFSM
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 