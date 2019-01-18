/*******************************************************************
 * FileName: PeaceNPC.cs
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
            public class PeaceNPC : Character {
                public static Character CreateInstance(string id, Vector3 position) {
                    return new PeaceNPC(id, position);
                } // end CreateInstance

                private PeaceNPC(string id, Vector3 position) : base(id, 
                    ObjectTool.InstantiateGo(id, ResourcesTool.LoadPrefab(id), null, position, Vector3.zero, Vector3.one)) {
                    gameObject.layer = LayerConfig.NPC;
                    m_info = new NPCharacterInfo(config.name, this);
                    m_avatar = new PeaceNPCAvatar(id, gameObject.AddComponent<Animation>());
                    m_surface = new CharacterSurface(transform.GetComponentInChildren<SkinnedMeshRenderer>());
                    m_fsm = new PeaceNPCFSM(this);
                } // end PeaceNPC

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
            } // end class PeaceNPC 
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider