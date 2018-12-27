/*******************************************************************
 * FileName: MainCharacterIdle.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterIdle : ICharacterState {
                public string id { get { return "idle"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "idle"; } }
                private IMainCharacter mainCharacter;

                public MainCharacterIdle(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end MainCharacterIdle

                public void DoBeforeEntering() {
                    mainCharacter.avatar.Play(anim);
                    mainCharacter.surface.FurlWeapon();
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.input.joystickDir.magnitude > 0f) {
                        mainCharacter.fsm.PerformTransition("walk");
                    } // end if
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MainCharacterIdle
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 
