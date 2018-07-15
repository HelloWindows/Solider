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
                public static NPCAttribute operator +(NPCAttribute role, TreatData data) {
                    role.HP += data.HP;
                    role.MP += data.MP;

                    if (data.HPR > 0) {
                        int value = role.XHP - role.HP;
                        value = (int)(value * data.HPR / 100f);
                        role.HP += value;
                    } // end if

                    if (data.MPR > 0) {
                        int value = role.XMP - role.MP;
                        value = (int)(value * data.MPR / 100f);
                        role.MP += value;
                    } // end if

                    if (data.XHPR > 0) {
                        role.HP += (int)(role.XHP * data.XHPR / 100f);
                    } // end if

                    if (data.XMPR > 0) {
                        role.MP += (int)(role.XMP * data.XMPR / 100f);
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

                /// <summary>
                /// HP 和 MP 损失
                /// </summary>
                /// <param name="npc"> 角色数据 </param>
                /// <param name="data"> HP 与 MP 数据 </param>
                /// <returns> 结果数据 </returns>
                public static NPCAttribute operator -(NPCAttribute npc, TreatData data) {
                    if (npc.inv) return npc;
                    // end if
                    npc.HP -= data.HP;
                    npc.MP -= data.MP;

                    if (data.HPR > 0) {
                        int value = npc.XHP - npc.HP;
                        value = (int)(value * data.HPR / 100f);
                        npc.HP -= value;
                    } // end if

                    if (data.MPR > 0) {
                        int value = npc.XMP - npc.MP;
                        value = (int)(value * data.MPR / 100f);
                        npc.MP -= value;
                    } // end if

                    if (data.XHPR > 0) {
                        npc.HP -= (int)(npc.XHP * data.XHPR / 100f);
                    } // end if

                    if (data.XMPR > 0) {
                        npc.MP -= (int)(npc.XMP * data.XMPR / 100f);
                    } // end if

                    if (npc.HP < 0) npc.HP = 0;
                    // end if
                    if (npc.HP > npc.XHP) npc.HP = npc.XHP;
                    // end if
                    if (npc.MP < 0) npc.MP = 0;
                    // end if
                    if (npc.MP > npc.XMP) npc.MP = npc.XMP;
                    // end if
                    return npc;
                } // end operator -
            } // end class NPCAttribute
        } // end namespace Data
    } // end namespace Model
} // end namespace Custom 
