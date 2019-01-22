/*******************************************************************
 * FileName: SfixBossFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using Solider.Character.NPC;

namespace Solider {
    namespace Character {
        namespace Boss {
            public class SfixBossFSM : CharacterFSM {

                public SfixBossFSM(ISkillCharacter character) {
                    AddState(new EnemyNPCIdle(character));
                    AddState(new EnemyNPCWalk(character));
                    AddState(new SfixBossChase(character));
                    AddState(new Melee_NPCAttack_1(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end SfixBossFSM          
            } // end class SfixBossFSM
        } // end namespace Boss
    } // end namespace Character
} // end namespace Solider 