/*******************************************************************
 * FileName: Range_NeutralNPCAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Range_NeutralNPCAvatar : CharacterAvatar {

                public Range_NeutralNPCAvatar(string id, Animation avatar) : base(avatar) {
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_idle"), "idle");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_attack_1"), "attack_1");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_run"), "run");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_hurt"), "hurt");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_die"), "die");
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                } // end Range_NeutralNPCAvatar          
            } // end class Range_NeutralNPCAvatar
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 
