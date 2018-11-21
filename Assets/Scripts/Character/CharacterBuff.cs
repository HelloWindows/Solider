/*******************************************************************
 * FileName: CharacterBuff.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Broadcast;
using Solider.Character.Interface;
using Solider.Config.Icon;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        public class CharacterBuff : ICharacterBuff{
            #region /************* BuffTimer ************/
            private class BuffTimer {
                private float time;
                public BuffInfo buffInfo { get; private set; }
                public float schedule { get { return time / buffInfo.LOT; } }

                public BuffTimer(BuffInfo buffInfo) {
                    this.buffInfo = buffInfo;
                    time = buffInfo.LOT;
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
                BroadcastCenter.Broadcast(BroadcastType.BuffChange);
            } // end Update

            public void InsertBuff(BuffInfo buffInfo) {
                if (null == buffInfo) return;
                // end if
                for (int i = 0; i < buffList.Count; i++) {
                    if (buffList[i].buffInfo.buffID != buffInfo.buffID) continue;
                    // end if
                    buffList[i] = new BuffTimer(buffInfo);
                    return;
                } // end for
                buffList.Add(new BuffTimer(buffInfo));
                BroadcastCenter.Broadcast(BroadcastType.BuffChange);
            } // end InsertBuff

            public List<BuffInfo> GetBuffInfoList() {
                if (buffList.Count == 0) return null;
                // end if
                List<BuffInfo> list = new List<BuffInfo>();
                for (int i = 0; i < buffList.Count; i++) {
                    list.Add(buffList[i].buffInfo);
                } // end for
                return list;
            } // end GetBuffInfoList

            public List<float> GetScheduleList() {
                if (buffList.Count == 0) return null;
                // end if
                List<float> list = new List<float>();
                for (int i = 0; i < buffList.Count; i++) {
                    list.Add(buffList[i].schedule);
                } // end for
                return list;
            } // end GetScheduleList
        } // end class CharacterBuff 
    } // end namespace Character
} // end namespace Solider