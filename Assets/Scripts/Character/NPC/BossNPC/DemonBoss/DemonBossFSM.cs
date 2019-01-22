/*******************************************************************
 * FileName: DemonBossFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using Solider.Character.NPC;

namespace Solider {
    namespace Character {
        namespace Boss {
            public class DemonBossFSM : CharacterFSM {

                public DemonBossFSM(ISkillCharacter character) {
                    AddState(new EnemyNPCIdle(character));
                    AddState(new EnemyNPCWalk(character));
                    AddState(new DemonBossChase(character));
                    AddState(new Melee_NPCAttack_1(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end DemonBossFSM          
            } // end class DemonBossFSM
        } // end namespace Boss
    } // end namespace Character
} // end namespace Solider 