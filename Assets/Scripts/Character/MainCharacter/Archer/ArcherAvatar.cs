/*******************************************************************
 * FileName: ArcherAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherAvatar : CharacterAvatar {
                public ArcherAvatar(Animation avatar) : base(avatar) {
                    string prefix = "Character/Hero/Archer/Animation/";
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "idle"), "idle");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "walk"), "walk");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "wait"), "wait");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "run"), "run");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "pose"), "pose");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "hurt"), "hurt");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "die"), "die");

                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill1_1"), "skill1_1");
                    avatar["skill1_1"].speed = 0.2f;
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill1_2"), "skill1_2");
                    avatar["skill1_2"].speed = 0.2f;
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "attack"), "attack");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "attCrit"), "attCrit");

                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill2_1"), "skill2_1");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill2_2"), "skill2_2");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill2_3"), "skill2_3");

                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill3_1"), "skill3_1");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill3_2"), "skill3_2");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill3_3"), "skill3_3");
                } // end SwordsmanAvatar
            } // end class ArcherAvatar
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 