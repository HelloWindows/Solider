/*******************************************************************
 * FileName: MagicianFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MagicianFSM : CharacterFSM {

                public MagicianFSM(IMainCharacter character) {
                    AddState(new MainCharacterWait(character));
                    AddState(new MainCharacterWalk(character));
                    AddState(new MainCharacterIdle(character));
                    AddState(new MainCharacterRun(character));
                    AddState(new MagicianAttack1(character));
                    AddState(new MainCharacterDie(character));
                    AddState(new MainCharacterHurt(character));
                } // end MagicianFSM       
            } // end class MagicianFSM 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider