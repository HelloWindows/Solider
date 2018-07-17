/*******************************************************************
 * FileName: NPCAttribute.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Model {
        namespace Data {
            public class NPCAttribute : AttributeData {
                public bool inv { get; private set; }
                public bool cro { get; private set; }

                public NPCAttribute(string jsonStr) { 

                } // end NPCAttribute

                /// <summary>
                /// 受到攻击
                /// </summary>
                /// <param name="npc"> npc数据 </param>
                /// <param name="att"> 攻击数据 </param>
                /// <returns> 结果数据 </returns>
                public static NPCAttribute operator +(NPCAttribute npc, AttackData att) {
                    if (npc.inv || att.ismiss) return npc;
                    // end if
                    int atk = att.ATK - npc.DEF;
                    if (atk < 0) atk = 0;
                    // end if
                    int mgk = att.MGK - npc.RGS;
                    if (mgk < 0) mgk = 0;
                    // end if
                    int value = atk + mgk;
                    if (value <= 0) value = 1;
                    // end if
                    npc.HP -= value;
                    return npc;
                } // end operator +

                /// <summary>
                /// HP 和 MP 增益
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="data"> HP 与 MP 数据 </param>
                /// <returns> 结果数据 </returns>
                public static NPCAttribute operator +(NPCAttribute role, FairData data) {
                    role.HP += data.HP;
                    role.MP += data.MP;

                    if (data.HPP > 0) {
                        int value = role.XHP - role.HP;
                        value = (int)(value * data.HPP / 100f);
                        role.HP += value;
                    } // end if

                    if (data.MPP > 0) {
                        int value = role.XMP - role.MP;
                        value = (int)(value * data.MPP / 100f);
                        role.MP += value;
                    } // end if

                    if (data.XHPP > 0) {
                        role.HP += (int)(role.XHP * data.XHPP / 100f);
                    } // end if

                    if (data.XMPP > 0) {
                        role.MP += (int)(role.XMP * data.XMPP / 100f);
                    } // end if

                    if (role.HP < 0) role.HP = 0;
                    // end if
                    if (role.HP > role.XHP) role.HP = role.XHP;
                    // end if
                    if (role.MP < 0) role.MP = 0;
                    // end if
                    if (role.MP > role.XMP) role.MP = role.XMP;
                    // end if
                    return role;
                } // end operator +
            } // end class NPCAttribute
        } // end namespace Data
    } // end namespace Model
} // end namespace Custom 
