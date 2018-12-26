﻿/*******************************************************************
 * FileName: MainCharacterPack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using System.Collections.Generic;
using Framework.Config;
using Solider.Model.Interface;
using Solider.Model;
using Solider.Manager;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterPack : IPackInfo {
                private IWearInfo wearInfo;
                private Dictionary<string, IPack> packDict;

                public MainCharacterPack(string roleType, ICharacterCenter center) {
                    string username = GameManager.playerInfo.username;
                    int roleindex = GameManager.playerInfo.roleindex;
                    packDict = new Dictionary<string, IPack>();
                    IEquipPack equipPack = new EquipPack(username, roleindex, ConstConfig.EQUIP, roleType, center);
                    wearInfo = equipPack;
                    packDict.Add(ConstConfig.EQUIP, equipPack);
                    packDict.Add(ConstConfig.CONSUME, new Pack(username, roleindex, ConstConfig.CONSUME));
                    packDict.Add(ConstConfig.STUFF, new Pack(username, roleindex, ConstConfig.STUFF));
                    packDict.Add(ConstConfig.PRINT, new Pack(username, roleindex, ConstConfig.PRINT));
                } // end MainCharacterPack

                public IWearInfo GetWearInfo() {
                    return wearInfo;
                } // end GetWearInfo

                public bool PackItem(string id, int count) {
                    IPack pack = GetItemPack(Configs.itemConfig.GetItemType(id));
                    if (null == pack) return false;
                    // end if
                    return pack.PackItem(id, count);
                } // end PackItems

                public IPack GetItemPack(string name) {
                    if (packDict.ContainsKey(name)) {
                        return packDict[name];
                    } // end if
                    return null;
                } // end GetItemPack
            } // end class MainCharacterPack 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider