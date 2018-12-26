/*******************************************************************
 * FileName: MainCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
using Framework.Custom.Input;
using Framework.Interface.Input;
using Solider.Character.Interface;
using Solider.Model.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public abstract class MainCharacter : Character, IMainCharacter {
                public IPackInfo pack { get; private set; }
                public IInputCenter input { get { return m_input; } }
                public ICharacterSkill skill { get { return m_skill; } }
                public IMainCharacterSurface surface { get { return m_surface; } }

                private CrossInput m_input;
                private CharacterSkill m_skill;
                protected MainCharacterSurface m_surface;

                protected MainCharacter(string id, string roleType, GameObject gameObject) : base(id, gameObject) {
                    m_input = new CrossInput();
                    m_skill = new CharacterSkill(this);
                    pack = new MainCharacterPack(roleType, center);
                } // end MainCharacter

                public override void Update() {
                    base.Update();
                    m_skill.Update();
                } // end Update

                public override void Dispose() {
                    m_input.Dispose();
                    base.Dispose();
                } // end Dispose
            } // end class MainCharacter
        } // end namespace MainCharacter
    } // end namespace Character 
} // end namespace Solider 
