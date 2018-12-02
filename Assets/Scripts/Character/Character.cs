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
            public IFSM fsm { get; protected set; }
            public ICharacterAduio audio { get; protected set; }
            public ICharacterMove move { get; protected set; }
            public ICharacterInfo info { get; protected set; }
            public ICharacterBuff buff { get; protected set; }
            public ICharacterAvatar avatar { get; protected set; }
            public ICharacterConfig config { get; protected set; }
            public Vector3 position { get { return null == transform ? Vector3.zero : transform.position; } }
            protected IFSMSystem fsmSystem;
            protected GameObject gameObject;
            protected Transform transform;

            protected Character(string id, GameObject gameObject) {
                this.id = id;
                isDisposed = false;
                this.gameObject = gameObject;
                transform = gameObject.transform;
                hashID = gameObject.GetHashCode().ToString();
                gameObject.name = hashID;
                config = Configs.characterConfig.GetCharacterConfig(id);
            } // end Character

            public virtual void Update(float deltaTime) {
                info.Update(deltaTime);
                fsmSystem.Update(deltaTime);
            } // end Update

            public virtual void Dispose() {
                if (true == isDisposed) return;
                // end if
                if (null != gameObject) Object.Destroy(gameObject); 
                // end if
                if (null != audio) audio.Dispose();
                // end if
                if (null != info) info.Dispose();
                // end if
                isDisposed = true;
            } // end Dispose
        } // end class Character
    } // end namespace Character 
} // end namespace Solider 
