/*******************************************************************
 * FileName: SwordmanFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanFSM : CharacterFSM {

                public SwordmanFSM(IMainCharacter character) {
                    AddState(new MainCharacterWalk(character));
                    AddState(new MainCharacterIdle(character));
                    AddState(new MainCharacterRun(character));
                    AddState(new MainCharacterWait(character));
                    AddState(new SwordmanAttack1(character));
                    AddState(new MainCharacterDie(character));
                    AddState(new MainCharacterHurt(character));
                } // end SwordmanFSM          
            } // end class SwordmanFSM
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 
