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
        namespace Swordman {
            public class SwordmanAvatar : IAvatar {
                public bool isPlaying {
                    get {
                        return avatar.isPlaying;
                    } // end get
                } // end isPlaying

                private Animation avatar;

                public SwordmanAvatar(Animation avatar) {
                    this.avatar = avatar;
                    string prefix = "Animation/Hero/Swordman/";
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "idle"), "idle");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "walk"), "walk");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "wait"), "wait");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "run"), "run");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "pose"), "pose");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "victory"), "victory");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "hurt"), "hurt");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "die"), "die");
                    for (int i = 1; i < 13; i++) {
                        avatar.AddClip(Resources.Load<AnimationClip>(prefix + "attack_" + i), "attack_" + i);
                    } // end for
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill1"), "skill1");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill2"), "skill2");
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + "skill3"), "skill3");
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach
                } // end SwordsmanAvatar

                public void Play(string name) {
                    avatar.Play(name);
                } // end Play

                public bool IsPlaying(string name) {
                    return avatar.IsPlaying(name);
                } // end IsPlaying

                public void PlayQueued(string[] names) {
                    if (null == names || names.Length < 1) return;
                    // end if
                    avatar.PlayQueued(names[0], QueueMode.PlayNow);
                    for (int i = 1; i < names.Length; i++) {
                        avatar.PlayQueued(names[i], QueueMode.CompleteOthers);
                    } // end for
                } // end Playe

                public AnimationState GetCurrentState(string name) {
                    if (false == avatar.IsPlaying(name)) return null;
                    // end if
                    return avatar[name];
                } // end GetAnimationState

                public void SetWrapMode(string name, WrapMode wrapMode) {
                    avatar[name].wrapMode = wrapMode;
                } // end SetWrapMode
            } // end class SwordmanAvatar
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Custom 
