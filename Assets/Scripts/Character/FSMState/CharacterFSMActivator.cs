/*******************************************************************
 * FileName: CharacterFSMActivator.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Character.Skill;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public static class CharacterFSMActivator {
                private static Dictionary<string, ICharacterFSMState> stateMap;
                private static Dictionary<string, ICharacterFSMState> StateMap {
                    get {
                        if (null == stateMap) {
                            stateMap = new Dictionary<string, ICharacterFSMState>();
                            PushState(new ArcherSkill1(null));
                            PushState(new ArcherSkill2(null));
                            PushState(new ArcherSkill3(null));
                            PushState(new MagicianSkill1(null));
                            PushState(new MagicianSkill2(null));
                            PushState(new MagicianSkill3(null));
                            PushState(new SwordmanSkill1(null));
                            PushState(new SwordmanSkill2(null));
                            PushState(new SwordmanSkill3(null));
                        } // end if
                        return stateMap;
                    } // end get
                } // end StateMap

                public static ICharacterFSMState GetCharacterFSMState(string id) {
                    ICharacterFSMState state;
                    if (StateMap.TryGetValue(id, out state)) return state;
                    // end if
                    DebugTool.ThrowException("CharacterFSMActivator GetCharacterFSMState id is error!!! ID:" + id);
                    return null;
                } // end GetCharacterFSMState

                private static void PushState(ICharacterFSMState state) {
                    if (null == state) {
                        DebugTool.ThrowException("CharacterFSMActivator PushState state is null!!!");
                        return;
                    } // end if
                    if (stateMap.ContainsKey(state.id)) {
                        DebugTool.ThrowException("CharacterFSMActivator PushState state id is repeat!!!  ID:" + state.id);
                        return;
                    } // end if
                    stateMap.Add(state.id, state);
                } // end PushState
            } // end class CharacterFSMActivator
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 
