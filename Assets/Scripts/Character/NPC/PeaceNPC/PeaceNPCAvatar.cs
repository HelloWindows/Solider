/*******************************************************************
 * FileName: PeaceNPCAvatar.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class PeaceNPCAvatar : CharacterAvatar {

                public PeaceNPCAvatar(string id, Animation avatar) : base(avatar) {
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_wait"), "wait");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_run"), "run");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_hurt"), "hurt");
                    avatar.AddClip(ResourcesTool.LoadAnimationClip(id + "_die"), "die");
                } // end PeaceNPCAvatar          
            } // end class PeaceNPCAvatar
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 