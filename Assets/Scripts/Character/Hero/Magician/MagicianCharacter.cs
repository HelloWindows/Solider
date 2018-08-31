/*******************************************************************
 * FileName: MagicianCharacter.cs
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
        namespace Magician {
            public class MagicianCharacter : ICharacter {
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

                public MagicianCharacter(Vector3 pos, string name) {
                    isDisposed = false;
                    gameObject = ObjectTool.InstantiateGo(name,
                        Configs.prefabConfig.GetPath(ConstConfig.MAGICIAN), null, pos, Vector3.zero, Vector3.one);
                    info = new Model.CharacterInfo(gameObject.GetHashCode(), name, ConstConfig.MAGICIAN);
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
                } // end Start

                public void Update(float deltaTime) {
                    fsmSystem.Update(deltaTime);
                } // end Update

                public void Dispose() {
                } // end Dispose
            } // end class MagicianCharacter 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider