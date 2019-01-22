/*******************************************************************
 * FileName: SfixBossAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Boss {
            public class SfixBossAvatar : CharacterAvatar {

                public SfixBossAvatar(string id, Animation avatar) : base(avatar) {
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_idle"), "idle");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_attack_1"), "attack_1");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_run"), "run");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_hurt"), "hurt");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_die"), "die");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_skill1_1"), "skill1_1");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_skill1_2"), "skill1_2");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_skill1_3"), "skill1_3");
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                    avatar["skill1_1"].speed = 0.2f;
                    avatar["skill1_3"].speed = 0.2f;
                } // end SfixBossAvatar          
            } // end class SfixBossAvatar
        } // end namespace Boss
    } // end namespace Character
} // end namespace Solider 