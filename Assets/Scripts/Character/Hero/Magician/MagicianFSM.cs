/*******************************************************************
 * FileName: MagicianFSM.cs
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
        namespace Magician {
            public class MagicianFSM : FSMSystem {
                public MagicianFSM(ICharacter character, IIputInfo input) {
                    AddState(new HeroIdle("idle", character, input));
                    AddState(new HeroWalk("walk", character, input));
                    AddState(new HeroWait("wait", character, input));
                    AddState(new HeroRun("run", character, input));
                    AddState(new HeroHurt("hurt", character));
                    AddState(new HeroDie("die", character));

                    AddState(new MagicianAttack1("atkStep1", character, input));
                    AddState(new MagicianAttack2("atkStep2", character, input));
                    AddState(new MagicianAttack3("atkStep3", character));
                    AddState(new MagicianSkill1("skill1", character));
                    AddState(new MagicianSkill2("skill2", character));
                    AddState(new MagicianSkill3("skill3", character));
                } // end SwordmanFSM
            } // end class MagicianFSM 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider