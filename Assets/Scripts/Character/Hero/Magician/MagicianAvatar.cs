﻿/*******************************************************************
 * FileName: MagicianAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianAvatar : CharacterAvatar {
                public MagicianAvatar(Animation avatar) : base(avatar) {
                    string prefix = "Character/Hero/Magician/Animation/";
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "idle"), "idle");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "walk"), "walk");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "wait"), "wait");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "run"), "run");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "pose"), "pose");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "hurt"), "hurt");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "die"), "die");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill1"), "skill1");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill2"), "skill2");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill3"), "skill3");
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                    for (int i = 1; i < 4; i++) {
                        for (int j = 1; j < 4; j++) {
                            string name = "attack" + i + "_" + j;
                            avatar.AddClip(Resources.Load<AnimationClip>(prefix + name), name);
                        } // end for
                    } // end for
                } // end SwordsmanAvatar
            } // end class MagicianAvatar 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider