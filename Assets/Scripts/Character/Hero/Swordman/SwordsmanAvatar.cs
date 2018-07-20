/*******************************************************************
 * FileName: SwordsmanAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class SwordsmanAvatar : IAvatar {
            private Animation avatar;

            public SwordsmanAvatar(Animation avatar) {
                this.avatar = avatar;
                string prefix = "Animation/Hero/Swordman/";
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "idle"), "idle");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "walk"), "walk");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "run"), "run");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "pose"), "pose");             
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "victory"), "victory");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "wait"), "wait");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "hurt"), "hurt");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "die"), "die");
                for (int i = 1; i < 13; i++) {
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "attack_" + i), "attack_" + i);
                } // end for
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill1"), "skill1");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill2"), "skill2");
                avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill3"), "skill3");
                avatar.CrossFade("idle");

                foreach (AnimationState state in avatar) {
                    state.speed = 0.5f;
                   
                } // end foreach
            } // end SwordsmanAvatar

            public void Play(string name) {
                avatar.CrossFade(name);
            } // end Play
        } // end class SwordsmanAvatar
    } // end namespace Character
} // end namespace Custom 
