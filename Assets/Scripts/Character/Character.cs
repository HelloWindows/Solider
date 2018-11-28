/*******************************************************************
 * FileName: Character.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        public abstract class Character : ICharacter {
            public bool isDisposed { get; private set; }
            public int id { get; private set; }
            public IFSM fsm { get; protected set; }
            public IIputInfo input { get; protected set; }
            public ICharacterSurface surface { get; protected set; }
            public ICharacterAduio audio { get; protected set; }
            public ICharacterMove move { get; protected set; }
            public ICharacterInfo info { get; protected set; }
            public ICharacterBuff buff { get; protected set; }
            public ICharacterAvatar avatar { get; protected set; }
            public Vector3 position { get { return null == transform ? Vector3.zero : transform.position; } }
            protected IFSMSystem fsmSystem;
            protected GameObject gameObject;
            protected Transform transform;

            protected Character(GameObject gameObject) {
                isDisposed = false;
                this.gameObject = gameObject;
                transform = gameObject.transform;
                id = gameObject.GetHashCode();
            } // end Character

            public void Update(float deltaTime) {
                fsmSystem.Update(deltaTime);
            } // end Update

            public void Dispose() {
                if (true == isDisposed) return;
                // end if
                if (null == gameObject) return;
                // end if
                Object.Destroy(gameObject);
                surface.Dispose();
                audio.Dispose();
                info.Dispose();
                isDisposed = true;
            } // end Dispose
        } // end class Character
    } // end namespace Character 
} // end namespace Solider 
