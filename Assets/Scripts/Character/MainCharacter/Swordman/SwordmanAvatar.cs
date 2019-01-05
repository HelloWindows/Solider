/*******************************************************************
 * FileName: SwordsmanAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanAvatar : CharacterAvatar {
                public SwordmanAvatar(Animation avatar) : base(avatar) {
                    string prefix = "swordman_";
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "idle"), "idle");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "walk"), "walk");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "wait"), "wait");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "run"), "run");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "pose"), "pose");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "hurt"), "hurt");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "die"), "die");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill1"), "skill1");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill2"), "skill2");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill3"), "skill3");
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                    for (int i = 1; i < 5; i++) {
                        for (int j = 1; j < 4; j++) {
                            string name = "attack" + i + "_" + j;
                            avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + name), name);
                        } // end for
                    } // end for
                } // end SwordsmanAvatar
            } // end class SwordmanAvatar
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 
