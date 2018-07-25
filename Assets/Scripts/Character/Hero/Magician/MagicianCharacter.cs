/*******************************************************************
 * FileName: MagicianCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
using Framework.FSM.Interface;
using Framework.Interface.Audio;
using Framework.Interface.Input;
using Solider.Character.Hero;
using Solider.Character.Interface;
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianCharacter : MonoBehaviour, ICharacter {
                public IFSM fsm { get; private set; }
                public IAvatar avatar { get; private set; }
                public ISurface surface { get; private set; }
                public new IAudioSound audio { get; private set; }
                public ICharacterMove move { get; private set; }
                public Vector3 position { get { return transform.position; } }
                private IIputInfo input;
                private IFSMSystem fsmSystem;

                void Start() {
                    input = new CrossInput();
                    gameObject.AddComponent<AudioListener>();
                    move = new HeroMove(gameObject.GetComponent<Rigidbody>());
                    avatar = new MagicianAvatar(gameObject.AddComponent<Animation>());
                    audio = new CharacterAduio(gameObject.AddComponent<AudioSource>());
                    SkinnedMeshRenderer meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
                    Transform liftTrans = null;
                    Transform furlTrans = null;
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "right_hand") {
                            liftTrans = child;
                            break;
                        } // end if
                    } // end foreach
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "weapon_spine") {
                            furlTrans = child;
                            break;
                        } // end if
                    } // end foreach
                    surface = new CharacterSurface(liftTrans, furlTrans, meshRenderer);
                    fsmSystem = new MagicianFSM(this, input);
                    fsm = fsmSystem as IFSM;

                    surface.ReloadWeapon("staff1");
                    surface.LiftWeapon();
                } // end Start

                private void Update() {
                    fsmSystem.Update(Time.deltaTime);
                } // end Update
            } // end class MagicianCharacter 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider