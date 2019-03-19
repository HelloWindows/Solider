﻿/*******************************************************************
 * FileName: Range_NeutralNPC.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Tools;
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace NPC {
            public class Range_NeutralNPC : Character {

                public static Character CreateInstance(string id, Vector3 position) {
                    return new Range_NeutralNPC(id, position);
                } // end CreateInstance

                private Range_NeutralNPC(string id, Vector3 position) : base(id, Object.Instantiate(ResourcesTool.LoadPrefab(id))) {
                    gameObject.layer = LayerConfig.NPC;
                    transform.position = position;
                    transform.rotation = Quaternion.identity;
                    m_info = new NPCharacterInfo(config.name, this);
                    m_avatar = new NormalNPCAvatar(id, gameObject.AddComponent<Animation>());
                    m_surface = new CharacterSurface(transform.GetComponentInChildren<SkinnedMeshRenderer>());
                    m_fsm = new Range_NeutralNPCFSM(this);
                } // end Range_NeutralNPC

                public override void Update() {
                    base.Update();
                    m_info.Update();
                    m_fsm.Update();
                } // end Update

                public override void Dispose() {
                    if (null != m_info) m_info.Dispose();
                    // end if
                    if (null != m_avatar) m_avatar.Dispose();
                    // end if
                    base.Dispose();
                } // end Dispose
            } // end class Range_NeutralNPC 
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider