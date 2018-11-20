/*******************************************************************
 * FileName: CharacterBuff.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Icon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Solider {
    namespace Character {
        public class CharacterBuff {
            #region /************* BuffTimer ************/
            private class BuffTimer {
                private float time;
                public BuffInfo buffInfo { get; private set; }

                public BuffTimer(BuffInfo buffInfo) {
                    this.buffInfo = buffInfo;
                    time = buffInfo.HOT;
                } // end ObjectTimer

                public bool IsOverTime(float deltaTime) {
                    time -= deltaTime;
                    if (time > 0) return false;
                    // end if
                    return true;
                } // end IsOverTime
            } // end class BuffTimer
            #endregion
            private List<int> signList;
            private List<BuffTimer> buffList;

            public CharacterBuff() {
                signList = new List<int>();
                buffList = new List<BuffTimer>();
            } // end CharacterBuff

            public void Update(float deltaTime) {
                if (buffList.Count == 0) return;
                // end if
                signList.Clear();
                for (int i = 0; i < buffList.Count; i++) {
                    int index = i;
                    if (buffList[index].IsOverTime(deltaTime)) signList.Add(index);
                    // end if
                } // end for
                if (signList.Count == 0) return;
                // end if
                for (int i = 0; i < signList.Count; i++) {
                    buffList.RemoveAt(signList[i]);
                } // end for
            } // end Update

            public void InsertBuff(BuffInfo buffInfo) {
                for (int i = 0; i < buffList.Count; i++) {
                    if (buffList[i].buffInfo.buffID != buffInfo.buffID) continue;
                    // end if
                    buffList[i] = new BuffTimer(buffInfo);
                    return;
                } // end for
                buffList.Add(new BuffTimer(buffInfo));
            } // end InsertBuff
        } // end class CharacterBuff 
    } // end namespace Character
} // end namespace Solider