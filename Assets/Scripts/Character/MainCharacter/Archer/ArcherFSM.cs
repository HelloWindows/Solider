/*******************************************************************
 * FileName: ArcherFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherFSM : CharacterFSM {

                public ArcherFSM(IMainCharacter character) {
                    AddState(new MainCharacterWait(character));
                    AddState(new MainCharacterWalk(character));
                    AddState(new MainCharacterIdle(character));
                    AddState(new MainCharacterRun(character));
                    AddState(new ArcherAttack1(character));
                    AddState(new MainCharacterDie(character));
                    AddState(new MainCharacterHurt(character));
                } // end ArcherFSM
            } // end class Archer
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 
