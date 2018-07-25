/*******************************************************************
 * FileName: ArcherFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM;
using Framework.Interface.Input;
using Solider.Character.FSMState;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherFSM : FSMSystem {
                public ArcherFSM(ICharacter character, IIputInfo input) {
                    AddState(new HeroIdle("idle", character, input));
                    AddState(new HeroWalk("walk", character, input));
                    AddState(new HeroWait("wait", character, input));
                    AddState(new HeroRun("run", character, input));
                    AddState(new HeroHurt("hurt", character));
                    AddState(new HeroDie("die", character));

                    AddState(new ArcherAttack("atkStep1", "atkStep2", character, input));
                    AddState(new ArcherAttack("atkStep2", "attCrit", character, input));
                    AddState(new ArcherCrit("attCrit", character));
                    AddState(new ArcherSkill1("skill1", character));
                    AddState(new ArcherSkill2("skill2", character));
                    AddState(new ArcherSkill3("skill3", character));
                    PerformTransition("idle");
                } // end ArcherFSM
            } // end class Archer
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 
