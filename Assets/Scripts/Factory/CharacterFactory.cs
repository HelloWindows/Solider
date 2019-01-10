using Framework.Config.Const;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Character.MainCharacter;
using Solider.Character.NPC;
using Solider.Manager;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Factory {
            public class CharacterFactory : ICharacterFactory, IDisposable {
                public IMainCharacter mainCharacter { get { return m_mainCharacter; } }
                private MainCharacter.MainCharacter m_mainCharacter;
                private List<Character> characterList;

                public CharacterFactory() {
                    characterList = new List<Character>();
                } // end CharacterFactory

                public void Update() {
                    for (int i = 0; i < characterList.Count; i++) {
                        characterList[i].Update();
                    } // end for
                } // end Update

                public void CreateMainCharacter(Vector3 position) {
                    if (null == GameManager.playerInfo || null == GameManager.playerInfo.roleType ||
                        GameManager.playerInfo.roleType == "" || null != m_mainCharacter) {
                        DebugTool.ThrowException(GetType() + "CreateMainCharacter mainCharacter is exist!");
                        return;
                    } // end if
                    switch (GameManager.playerInfo.roleType) {
                        case ConstConfig.SWORDMAN:
                            m_mainCharacter = new SwordmanCharacter(ConstConfig.SWORDMAN, position, GameManager.playerInfo.rolename);
                            break;

                        case ConstConfig.ARCHER:
                            m_mainCharacter = new ArcherCharacter(ConstConfig.ARCHER, position, GameManager.playerInfo.rolename);
                            break;

                        case ConstConfig.MAGICIAN:
                            m_mainCharacter = new MagicianCharacter(ConstConfig.MAGICIAN, position, GameManager.playerInfo.rolename);
                            break;
                    } // end switch
                    if (null == m_mainCharacter) {
                        DebugTool.ThrowException(GetType() + "CreateMainCharacter mainCharacter is create fail! roleType:" + GameManager.playerInfo.roleType);
                        return;
                    } // end if
                    characterList.Add(m_mainCharacter);
                } // end CreateMainCharacter

                public void CreateNPC(string id, Vector3 position) {
                    characterList.Add(new PeaceNPC(id, position));
                } // end CreateNPC

                public bool GetNPCharacter(string hashID, out ICharacter npc) {
                    if (string.IsNullOrEmpty(hashID)) {
                        npc = null;
                        return false;
                    } // end if
                    for (int i = 0; i < characterList.Count; i++) {
                        if (characterList[i].hashID != hashID) continue;
                        // end if
                        npc = characterList[i];
                        return true;
                    } // end for
                    npc = null;
                    return false;
                } // end GerNPCharacter

                public void DisposeNPC(string hashID) {
                    for (int i = 0; i < characterList.Count; i++) {
                        if (characterList[i].hashID != hashID) continue;
                        // end if
                        characterList[i].Dispose();
                        characterList.RemoveAt(i);
                        return;
                    } // end for
                } // end DisposeNPC

                public void Dispose() {
                    if (null != m_mainCharacter) m_mainCharacter.Dispose();
                    // end if
                    for (int i = 0; i < characterList.Count; i++) {
                        characterList[i].Dispose();
                    } // end for
                } // end Dispose
            } // end class CharacterFactory 
        } // end namespace Factory
    } // end namespace Character
} // end  namespace Solider
