﻿/*******************************************************************
 * FileName: Character.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.FSM.Interface;
using Solider.Character.Interface;
using Solider.Config.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        public abstract class Character : ICharacter {
            public string id { get; private set; }
            public bool isDisposed { get; private set; }
            public string hashID { get; private set; }
            public IFSM fsm { get { return m_fsmSystem; } }
            public ICharacterMove move { get { return m_move; } }
            public ICharacterInfo info { get { return m_info; } }
            public ICharacterBuff buff { get { return m_buff; } }
            public ICharacterSkill skill { get { return m_skill; } }
            public ICharacterAudio audio { get { return m_audio; } }
            public ICharacterAvatar avatar { get { return m_avatar; } }
            public ICharacterConfig config { get; protected set; }
            public Vector3 position { get { return null == m_transform ? Vector3.zero : m_transform.position; } }

            private CharacterMove m_move;
            private CharacterBuff m_buff;
            private CharacterAduio m_audio;
            private CharacterSkill m_skill;

            protected CharacterInfo m_info;
            protected CharacterAvatar m_avatar;
            protected IFSMSystem m_fsmSystem;
            protected GameObject m_gameObject;
            protected Transform m_transform;

            protected Character(string id, GameObject gameObject) {
                this.id = id;
                isDisposed = false;
                m_gameObject = gameObject;
                m_transform = gameObject.transform;
                hashID = gameObject.GetHashCode().ToString();
                gameObject.name = hashID;
                config = Configs.characterConfig.GetCharacterConfig(id);

                m_move = new CharacterMove(m_transform);
                m_buff = new CharacterBuff();
                m_audio = new CharacterAduio(gameObject.AddComponent<AudioSource>());
                m_skill = new CharacterSkill(this);
            } // end Character

            public virtual void Update(float deltaTime) {
                m_info.Update(deltaTime);
                m_buff.Update(deltaTime);
                m_skill.Update(deltaTime);
                m_fsmSystem.Update(deltaTime);
            } // end Update

            public virtual void Dispose() {
                isDisposed = true;
                if (null != m_audio) {
                    m_audio.Dispose();
                    m_audio = null;
                } // end if
                if (null != m_info) {
                    m_info.Dispose();
                    m_info = null;
                } // end if
                m_transform = null;
                if (null != m_gameObject) Object.Destroy(m_gameObject);
                // end if
            } // end Dispose
        } // end class Character
    } // end namespace Character 
} // end namespace Solider 