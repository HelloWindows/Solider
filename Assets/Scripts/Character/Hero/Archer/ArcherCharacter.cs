/*******************************************************************
 * FileName: ArcherCharacter.cs
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
        namespace Archer {
            public class ArcherCharacter : ICharacter {
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
                private Transform transform { get { return gameObject.transform; } }

                public ArcherCharacter(Vector3 pos, string name) {
                    isDisposed = false;
                    gameObject = ObjectTool.InstantiateGo(name,
                        Configs.prefabConfig.GetPath(ConstConfig.ARCHER), null, pos, Vector3.zero, Vector3.one);
                    info = new Model.CharacterInfo(gameObject.GetHashCode(), name, ConstConfig.ARCHER);
                    input = new CrossInput();
                    gameObject.AddComponent<AudioListener>();
                    avatar = new ArcherAvatar(gameObject.AddComponent<Animation>());
                    move = new HeroMove(gameObject.GetComponent<Rigidbody>());
                    audio = new CharacterAduio(gameObject.AddComponent<AudioSource>());
                    SkinnedMeshRenderer meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
                    Transform wingTrans = null;
                    Transform liftTrans = null;
                    Transform furlTrans = null;
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "wing_spine") {
                            wingTrans = child;
                            break;
                        } // end if
                    } // end foreach
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "left_hand") {
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
                    surface = new CharacterSurface(wingTrans, liftTrans, furlTrans, meshRenderer);
                    surface.Freshen();
                    fsmSystem = new ArcherFSM(this, input);
                    fsm = fsmSystem as IFSM;
                } // end Start

                public void Update(float deltaTime) {
                    fsmSystem.Update(deltaTime);
                } // end Update

                public void Dispose() {
                    surface.Dispose();
                } // end Dispose
            } // end class ArcherCharacter
        } // end namespace Archer
    } // end namespace Character
} // end namespace Custom 
