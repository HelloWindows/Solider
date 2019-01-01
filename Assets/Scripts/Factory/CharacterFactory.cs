using Framework.Config.Const;
using Framework.Interface.Scene;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Character.MainCharacter;
using Solider.Manager;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Factory {
        public class CharacterFactory : ICharacterFactory, IDisposable {
            public IMainCharacter mainCharacter { get { return m_mainCharacter; } }
            private MainCharacter m_mainCharacter;
            private List<int> indexList = new List<int>();
            private List<Character.Character> characterList;

            public CharacterFactory() {
                indexList = new List<int>();
                characterList = new List<Character.Character>();
            } // end CharacterFactory

            public void Update() {
                indexList.Clear();
                for (int i = 0; i < characterList.Count; i++) {
                    if (characterList[i].isDisposed) indexList.Add(i);
                    // end if
                } // end for
                for (int i = 0; i < indexList.Count; i++) {
                    characterList.RemoveAt(indexList[i]);
                } // end for
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

            public void CreateNPC(Vector3 position) {
            } // end CreateNPC

            public void Dispose() {
                if (null != m_mainCharacter) m_mainCharacter.Dispose();
                // end if
            } // end Dispose
        } // end class CharacterFactory 
    } // end namespace Factory
} // end  namespace Solider
