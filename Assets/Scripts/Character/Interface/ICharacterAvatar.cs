/*******************************************************************
 * FileName: ICharacterAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterAvatar {
                /// <summary>
                /// 正在播动画
                /// </summary>
                bool isPlaying { get; }
                /// <summary>
                /// 播放对应的动画
                /// </summary>
                /// <param name="name"> 动画名 </param>
                void Play(string name);
                /// <summary>
                /// 对应的动画是否正在播放
                /// </summary>
                /// <param name="name"> 动画名 </param>
                /// <returns> 是否正在播放 </returns>
                bool IsPlaying(string name);
                /// <summary>
                /// 播放一组动画
                /// </summary>
                /// <param name="names"> 动画名顺序 </param>
                void PlayQueued(string[] names);
                /// <summary>
                /// 获得当前动画状态，如果当前动画名不同返回 null。Notice：如果动画是通过 PlayQueued 播放的，返回的是 Clone 的状态。名字为"动画名 - Queued Clone"
                /// </summary>
                /// <param name="name"> 动画名 </param>
                /// <returns> 当前动画状态 </returns>
                AnimationState GetCurrentState(string name);
            } // end interface ICharacterAvatar
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 
