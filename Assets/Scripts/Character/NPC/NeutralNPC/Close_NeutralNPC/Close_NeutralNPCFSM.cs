/*******************************************************************
 * FileName: Close_NeutralNPCFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Close_NeutralNPCFSM : CharacterFSM {

                public Close_NeutralNPCFSM(ICharacter character) {
                    AddState(new NeutralNPCIdle(character));
                    AddState(new NeutralNPCWalk(character));
                    AddState(new Close_NeutralNPCChase(character));
                    AddState(new Close_NeutralNPCAttack(character));
                    AddState(new NPCDie(character));
                    PerformTransition("idle");
                } // end Close_NeutralNPCFSM          
            } // end class Close_NeutralNPCFSM
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 