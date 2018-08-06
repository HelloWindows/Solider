/*******************************************************************
 * FileName: Swordsman.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Custom;
using Framework.FSM.Interface;
using Framework.Interface.Audio;
using Framework.Interface.Input;
using Framework.Tools;
using Solider.Character.Hero;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Swordman {
            public class SwordmanCharacter : ICharacter {
                public bool isDisposed { get; private set; }
                public IFSM fsm { get; private set; }
                public IAvatar avatar { get; private set; }
                public ISurface surface { get; private set; }
                public IAudioSound audio { get; private set; }
                public ICharacterMove move { get; private set; }
                public ICharacterInfo info { get; private set; }
                public Vector3 position { get { return transform.position; } }
                private IIputInfo input;
                private IFSMSystem fsmSystem;
                private GameObject gameObject;
                private Transform transform;

                public SwordmanCharacter(Vector3 pos, string name) {
                    isDisposed = false;
                    gameObject = ObjectTool.InstantiateGo(name, 
                        Configs.prefabConfig.GetPath(ConstConfig.SWORDMAN), null, pos, Vector3.zero, Vector3.one);
                    transform = gameObject.transform;
                    input = new CrossInput();
                    gameObject.AddComponent<AudioListener>();
                    info = new Model.CharacterInfo(gameObject.GetHashCode(), name, ConstConfig.SWORDMAN);
                    move = new HeroMove(gameObject.GetComponent<Rigidbody>());
                    avatar = new SwordmanAvatar(gameObject.AddComponent<Animation>());
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
                    fsmSystem = new SwordmanFSM(this, input);
                    fsm = fsmSystem as IFSM;
                } // end SwordmanCharacter

                public void Update(float deltaTime) {
                    fsmSystem.Update(deltaTime);
                } // end Update

                public void Dispose() {
                    isDisposed = true;
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                } // end Dispose
            } // end class SwordmanCharacter
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Custom 
