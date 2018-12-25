/*******************************************************************
 * FileName: MainCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Hero {
            public abstract class MainCharacter : Character, IMainCharacter {
                public IIputInfo input { get; protected set; }
                public ICharacterSkill skill { get { return m_skill; } }
                public IMainCharacterSurface surface { get; protected set; }

                private CharacterSkill m_skill;

                protected MainCharacter(string id, GameObject gameObject) : base(id, gameObject) {
                    m_skill = new CharacterSkill(this);
                } // end MainCharacter

                public override void Update(float deltaTime) {
                    base.Update(deltaTime);
                    m_skill.Update(deltaTime);
                } // end Update

                public override void Dispose() {
                    base.Dispose();
                    if (null != surface) {
                        surface.Dispose();
                        surface = null;
                    } // end if
                } // end Dispose
            } // end class MainCharacter
        } // end namespace Hero
    } // end namespace Character 
} // end namespace Solider 
