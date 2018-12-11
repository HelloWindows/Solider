/*******************************************************************
 * FileName: CharacterAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using System;
using UnityEngine;

namespace Solider {
    namespace Character {
        public abstract class CharacterAvatar : ICharacterAvatar, IDisposable {
            public bool isPlaying { get { return avatar.isPlaying; } } // end isPlaying
            protected Animation avatar;

            protected CharacterAvatar(Animation avatar) {
                this.avatar = avatar;
            } // end CharacterAvatar

            public void Play(string name) {
                avatar.Play(name);
            } // end Play

            public bool IsPlaying(string name) {
                return avatar.IsPlaying(name);
            } // end IsPlaying

            public void PlayQueued(string[] names) {
                if (null == names || names.Length < 1) return;
                // end if
                avatar.Play(names[0]);
                for (int i = 1; i < names.Length; i++) {
                    avatar.PlayQueued(names[i], QueueMode.CompleteOthers);
                } // end for
            } // end PlayQueued

            public AnimationState GetCurrentState(string name) {
                if (false == avatar.IsPlaying(name)) return null;
                // end if
                return avatar[name];
            } // end GetAnimationState

            public void Dispose() {
                if (null != avatar) UnityEngine.Object.Destroy(avatar);
                // end if
            } // end Dispose
        } // end class CharacterAvatar 
    } // end namespace Character
} // end namespace Solider