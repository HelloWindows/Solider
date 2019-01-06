/*******************************************************************
 * FileName: ArcherAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherAvatar : CharacterAvatar {
                public ArcherAvatar(Animation avatar) : base(avatar) {
                    string prefix = "archer_";
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "idle"), "idle");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "walk"), "walk");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "wait"), "wait");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "run"), "run");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "pose"), "pose");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "hurt"), "hurt");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "die"), "die");

                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill1_1"), "skill1_1");
                    avatar["skill1_1"].speed = 0.2f;
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill1_2"), "skill1_2");
                    avatar["skill1_2"].speed = 0.2f;
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "attack"), "attack");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "attCrit"), "attCrit");

                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill2_1"), "skill2_1");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill2_2"), "skill2_2");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill2_3"), "skill2_3");

                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill3_1"), "skill3_1");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill3_2"), "skill3_2");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(prefix + "skill3_3"), "skill3_3");
                } // end SwordsmanAvatar
            } // end class ArcherAvatar
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 