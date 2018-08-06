/*******************************************************************
 * FileName: SwordmanFSM.cs
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
        namespace Swordman {
            public class SwordmanFSM : FSMSystem {
                public SwordmanFSM(ICharacter character, IIputInfo input) {
                    AddState(new HeroIdle("idle", character, input));
                    AddState(new HeroWalk("walk", character, input));
                    AddState(new HeroWait("wait", character, input));
                    AddState(new HeroRun("run", character, input));
                    AddState(new HeroHurt("hurt", character));
                    AddState(new HeroDie("die", character));
                    AddState(new SwordmanAttack1("atkStep1", character, input));
                    AddState(new SwordmanAttack2("atkStep2", character, input));
                    AddState(new SwordmanAttack3("atkStep3", character, input));
                    AddState(new SwordmanAttack4("atkStep4", character));
                    AddState(new SwordmanSkill1("skill1", character));
                    AddState(new SwordmanSkill2("skill2", character, input));
                    AddState(new SwordmanSkill3("skill3", character));
                } // end SwordmanFSM
            } // end class SwordmanFSM
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Solider 
