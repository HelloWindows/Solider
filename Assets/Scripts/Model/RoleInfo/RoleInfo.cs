/*******************************************************************
 * FileName: RoleInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using System.Collections.Generic;
using Solider.Model.Data;
using Solider.Interface;
using Framework.Config;
using Solider.Config;

namespace Solider {
    namespace Model {
        public class RoleInfo : IRoleInfo {
            #region ******** 单例 ********
            private static RoleInfo instance;
            public static RoleInfo GetInstance(string roleID, string name, string roleType) {
                if (null == instance) instance = new RoleInfo(roleID, name, roleType);
                // end if
                return instance;
            } // end GetInstance
            #endregion

            public bool IsLive {
               get {
                    if (!isLive) return false;
                    // end if
                    if (roleArribute.HP <= 0) isLive = false;
                    // end if
                    return isLive;
                } // end get
            } // end IsLive
            private bool isLive;
            private EquipPack equipPack;
            private FairData selfTreat;
            private RoleAttribute roleArribute;
            private RoleAttribute tempArribute;
            private RoleInitAttribute roleInitArribute;
            private Dictionary<string, IPack> packDict;
            private readonly string[] equipTypeList = { ConstConfig.WEAPON, ConstConfig.ARMOE, ConstConfig.SHOES };

            private RoleInfo(string roleID, string name, string roleType) {
                packDict = new Dictionary<string, IPack>();
                equipPack = new EquipPack(roleID, ConstConfig.EQUIP, roleType);
                packDict.Add(ConstConfig.EQUIP, equipPack);
                packDict.Add(ConstConfig.CONSUME, new Pack(roleID, ConstConfig.CONSUME));
                packDict.Add(ConstConfig.STUFF, new Pack(roleID, ConstConfig.STUFF));

                selfTreat = new FairData();
                roleArribute = new RoleAttribute(roleID, name, roleType);
                tempArribute = new RoleAttribute(roleID, name, roleType);
                roleInitArribute = new RoleInitAttribute(roleID);
                GetAttributeData();
            } // end PlayerInfo

            public IWearInfo GetWearInfo() {
                return equipPack;
            } // end GetWearInfo

            public AttributeData GetAttributeData() {
                tempArribute += roleInitArribute;
                for (int i = 0; i < equipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                    EquipInfo info = equipPack.GetEquipInfo(equipTypeList[i]);
                    if (null == info) continue;
                    // end if
                    tempArribute += info;
                } // end for
                roleArribute += tempArribute;
                return roleArribute;
            } // end GetAttributeData

            public void PackItem(string id, int count) {
                IPack pack = GetItemPack(Configs.itemConfig.GetItemType(id));
                if (null == pack) return;
                // end if
                pack.PackItem(id, count);
            } // end PackItems

            public IPack GetItemPack(string name) {
                if (packDict.ContainsKey(name)) {
                    return packDict[name];
                } // end if
                return null;
            } // end GetItemPack

            public void SelfHealing() {
                GetAttributeData();
                selfTreat += roleArribute;
                roleArribute += selfTreat;
            } // end SelfHealing
        } // end class RoleInfo 
    } // end namespace Data
} // end namespace Solider