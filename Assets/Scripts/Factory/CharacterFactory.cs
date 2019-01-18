using Framework.Tools;
using Solider.Character.Interface;
using Solider.Factory.Proxy;
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
                    if (null == GameManager.playerInfo || null == GameManager.playerInfo.roletype ||
                        GameManager.playerInfo.roletype == "" || null != m_mainCharacter) {
                        DebugTool.ThrowException(GetType() + "CreateMainCharacter mainCharacter is exist!");
                        return;
                    } // end if
                    m_mainCharacter = MainCharacterProxy.CreateMainCharacter(GameManager.playerInfo.roletype, 
                        GameManager.playerInfo.rolename, position);
                    if (null == m_mainCharacter) {
                        DebugTool.ThrowException(GetType() + "CreateMainCharacter mainCharacter is create fail! roleType:" + GameManager.playerInfo.roletype);
                        return;
                    } // end if
                    characterList.Add(m_mainCharacter);
                } // end CreateMainCharacter

                public void CreateNPC(string id, Vector3 position) {
                    Character npc = NPCharacterProxy.CreateNPCharacter(id, position);
                    if (null == npc) {
                        DebugTool.ThrowException(GetType() + "CreateNPC result is null!! id:" + id);
                        return;
                    } // end if
                    characterList.Add(npc);
                } // end CreateNPC

                public ICharacter GetNPCharacter(string hashID) {
                    if (string.IsNullOrEmpty(hashID)) {
                        return null;
                    } // end if
                    for (int i = 0; i < characterList.Count; i++) {
                        if (characterList[i].hashID != hashID) continue;
                        // end if
                        return characterList[i];
                    } // end for
                    return null;
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
