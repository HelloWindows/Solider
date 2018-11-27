/*******************************************************************
 * FileName: FSMStateConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Framework.FSM.Interface;
using System.Collections.Generic;

namespace Framework {
    namespace Config {
        namespace FSM {
            public class FSMStateConfig {
                private static FSMStateConfig config;
                private Dictionary<string, IFSMState> characterStateMap;
                public static FSMStateConfig instance {
                    get {
                        if (null != config) return config;
                        // end if
                        config = new FSMStateConfig();
                        return config;
                    } // end get
                } // end instance

                /// <summary>
                /// 根据 ID 获取角色状态对象
                /// </summary>
                /// <param name="stateID"> 状态ID </param>
                /// <returns></returns>
                public IFSMState GetCharacterState(string stateID) {
                    if (false == characterStateMap.ContainsKey(stateID)) return null;
                    // end if
                    return characterStateMap[stateID];
                } // end GetState


                private FSMStateConfig() {
                    characterStateMap = new Dictionary<string, IFSMState>();
                    ConfigHoreStateMap();
                } // end FSMStateConfig

                private void ConfigHoreStateMap() {

                } // end ConfigHoreStateMap

                private void PushHoreStateMap(IFSMState state) {
                    if (characterStateMap.ContainsKey(state.id)) {
                        DebugTool.ThrowException("FSMStateConfig PushHoreStateMap repeat id: " + state.id);
                        return;
                    } // end if
                    characterStateMap[state.id] = state;
                } // end PushHoreStateMap
            } // end class FSMStateConfig 
        } // end namespace FSM
    } // end namespace Config
} // end namespace Framework