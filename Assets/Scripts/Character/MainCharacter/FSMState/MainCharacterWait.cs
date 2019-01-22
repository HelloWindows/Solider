/*******************************************************************
 * FileName: MainCharacterWait.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterWait : ICharacterState {
                public string id { get { return "wait"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "wait"; } }
                private IMainCharacter mainCharacter;

                public MainCharacterWait(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end MainCharacterWait

                public void DoBeforeEntering() {
                    mainCharacter.avatar.Play(anim);
                    mainCharacter.mainSurface.LiftWeapon();
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == mainCharacter.info.characterData.IsLive) {
                        mainCharacter.fsm.PerformTransition("die");
                        return;
                    } // end if
                    if (mainCharacter.input.joystickDir.magnitude > 0f) {
                        mainCharacter.fsm.PerformTransition("run");
                        return;
                    } // end if
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                    mainCharacter.input.RemoveListener(OnClickAttack);
                } // end DoBeforeLeaving

                private void OnClickAttack(ClickEvent type) {
                    if (ClickEvent.OnAttack != type) return;
                    // end if
                    mainCharacter.fsm.PerformTransition("attack");
                } // end OnClickAttack
            } // end class MainCharacterWait
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 
