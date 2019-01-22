/*******************************************************************
 * FileName: GledeBossFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using Solider.Character.NPC;

namespace Solider {
    namespace Character {
        namespace Boss {
            public class GledeBossFSM : CharacterFSM {

                public GledeBossFSM(ISkillCharacter character) {
                    AddState(new EnemyNPCIdle(character));
                    AddState(new EnemyNPCWalk(character));
                    AddState(new NPCChase(character));
                    AddState(new Glede_BossAttack_1(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end GledeBossFSM          
            } // end class GledeBossFSM
        } // end namespace Boss
    } // end namespace Character
} // end namespace Solider 