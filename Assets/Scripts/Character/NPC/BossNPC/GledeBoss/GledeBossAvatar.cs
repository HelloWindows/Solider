/*******************************************************************
 * FileName: GledeBossAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Boss {
            public class GledeBossAvatar : CharacterAvatar {

                public GledeBossAvatar(string id, Animation avatar) : base(avatar) {
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_idle"), "idle");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_attack_1"), "attack_1");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_run"), "run");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_hurt"), "hurt");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_die"), "die");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_skill1"), "skill1");
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                } // end GledeBossAvatar          
            } // end class GledeBossAvatar
        } // end namespace Boss
    } // end namespace Character
} // end namespace Solider 