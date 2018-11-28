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
using Framework.Interface.Input;
using Framework.Tools;
using Solider.Character.Hero;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianCharacter : Character {

                public MagicianCharacter(Vector3 pos, string name) : base(ObjectTool.InstantiateGo(name,
                    Configs.prefabConfig.GetPath(ConstConfig.MAGICIAN), null, pos, Vector3.zero, Vector3.one)) {
                    input = new CrossInput();
                    buff = new CharacterBuff();
                    move = new HeroMove(gameObject.GetComponent<Rigidbody>());
                    avatar = new MagicianAvatar(gameObject.AddComponent<Animation>());
                    audio = new CharacterAduio(gameObject.AddComponent<AudioSource>());
                    info = new Model.CharacterInfo(id, name, ConstConfig.MAGICIAN);
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
                    surface = new CharacterSurface(wingTrans, liftTrans, furlTrans, meshRenderer);
                    surface.Freshen();
                    fsmSystem = new MagicianFSM(this);
                    fsm = fsmSystem as IFSM;
                } // end MagicianCharacter
            } // end class MagicianCharacter 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider