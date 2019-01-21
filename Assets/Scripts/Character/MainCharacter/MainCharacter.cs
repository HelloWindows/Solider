/*******************************************************************
 * FileName: MainCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Framework.Custom.Input;
using Framework.Interface.Input;
using Solider.Character.Interface;
using Solider.Model.Interface;
using UnityEngine;
using Framework.Manager;
using Framework.Config.Game;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public abstract class MainCharacter : Character, IMainCharacter {
                public IPackInfo pack { get; private set; }
                public IInputCenter input { get { return m_input; } }
                public ICharacterSkill skill { get { return m_skill; } }
                public IMainCharacterSurface mainSurface { get { return m_mainSurface; } }

                private string lockNPC_hashID;
                private CrossInput m_input;
                private CharacterSkill m_skill;
                protected MainCharacterSurface m_mainSurface;

                protected MainCharacter(string id, string roleType, GameObject gameObject) : base(id, gameObject) {
                    m_input = new CrossInput();
                    m_skill = new CharacterSkill(this);
                    gameObject.layer = LayerConfig.Main;
                    pack = new MainCharacterPack(roleType, center);
                } // end MainCharacter

                public override void Update() {
                    base.Update();
                    m_skill.Update();
                    if (RayTool.PointerRaycastNPC(out lockNPC_hashID)) {
                        if (string.IsNullOrEmpty(lockNPC_hashID)) {
                            info.LockCharacter(null);
                            return;
                        } // end if
                        ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(lockNPC_hashID);
                        info.LockCharacter(npc);
                    } // end if
                } // end Update

                public override void Dispose() {
                    m_input.Dispose();
                    base.Dispose();
                } // end Dispose
            } // end class MainCharacter
        } // end namespace MainCharacter
    } // end namespace Character 
} // end namespace Solider 
