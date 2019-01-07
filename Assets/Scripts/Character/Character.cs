/*******************************************************************
 * FileName: Character.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Solider.Character.Interface;
using Solider.Config.Interface;
using System;
using UnityEngine;

namespace Solider {
    namespace Character {
        public abstract class Character : ICharacter, IDisposable  {
            public string id { get; private set; }
            public bool isDisposed { get; private set; }
            public string hashID { get; private set; }
            public ICharacterFSM fsm { get { return m_fsm; } }
            public ICharacterMove move { get { return m_move; } }
            public ICharacterInfo info { get { return m_info; } }
            public ICharacterBuff buff { get { return m_buff; } }
            public ICharacterAudio audio { get { return m_audio; } }
            public ICharacterAvatar avatar { get { return m_avatar; } }
            public ICharacterCenter center { get { return m_center; } }
            public ICharacterSurface surface { get { return m_surface; } }
            public ICharacterConfig config { get; private set; }
            public Vector3 position { get { return null == transform ? Vector3.zero : transform.position; } }

            private CharacterMove m_move;
            private CharacterBuff m_buff;
            private CharacterAduio m_audio;
            private CharacterCenter m_center;

            protected CharacterInfo m_info;
            protected CharacterAvatar m_avatar;
            protected CharacterFSM m_fsm;
            protected CharacterSurface m_surface;
            protected GameObject gameObject { get { return m_gameObject; } }
            protected Transform transform { get { return m_transform; } }

            private GameObject m_gameObject;
            private Transform m_transform;

            protected Character(string id, GameObject gameObject) {
                this.id = id;
                isDisposed = false;
                m_gameObject = gameObject;
                m_transform = gameObject.transform;
                hashID = gameObject.GetHashCode().ToString();
                gameObject.name = hashID;
                config = Configs.characterConfig.GetCharacterConfig(id);

                m_center = new CharacterCenter();
                m_move = new CharacterMove(transform);
                m_buff = new CharacterBuff(center);
                m_audio = new CharacterAduio(gameObject.AddComponent<AudioSource>());
            } // end Character

            public virtual void Update() {
                m_buff.Update();
            } // end Update

            public virtual void Dispose() {
                isDisposed = true;
                if (null != m_center) m_center.Dispose();
                // end if
                if (null != m_audio) m_audio.Dispose();
                // end if
                if (null != m_gameObject) UnityEngine.Object.Destroy(m_gameObject);
                // end if
                m_transform = null;
            } // end Dispose
        } // end class Character
    } // end namespace Character 
} // end namespace Solider 
