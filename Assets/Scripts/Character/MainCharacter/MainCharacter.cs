/*******************************************************************
 * FileName: MainCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Character.Interface;
using Solider.Model.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public abstract class MainCharacter : Character, IMainCharacter {
                public IPackInfo pack { get; private set; }
                public IIputInfo input { get; protected set; }
                public ICharacterSkill skill { get { return m_skill; } }
                public IMainCharacterSurface surface { get; protected set; }

                private CharacterSkill m_skill;

                protected MainCharacter(string id, string roleType, GameObject gameObject) : base(id, gameObject) {
                    m_skill = new CharacterSkill(this);
                    pack = new MainCharacterPack(roleType, center);
                } // end MainCharacter

                public override void Update(float deltaTime) {
                    base.Update(deltaTime);
                    m_skill.Update(deltaTime);
                } // end Update

                public override void Dispose() {
                    if (null != surface) surface.Dispose();
                    // end if
                    base.Dispose();
                } // end Dispose
            } // end class MainCharacter
        } // end namespace MainCharacter
    } // end namespace Character 
} // end namespace Solider 
