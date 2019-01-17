/*******************************************************************
 * FileName: DamageData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.ModelData.Interface;
using Framework.Tools;
using Solider.Character.Interface;

namespace Solider {
    namespace ModelData {
        namespace Data {
            public class DamageData : IDamageData {
                public string hashID { get; private set; }
                public int ATK { get; private set; }
                public int MGK { get; private set; }
                public float DEFR { get; private set; }
                public float RGSR { get; private set; }
                public float HIT { get; private set; }
                public bool iscrit { get; private set; }

                public DamageData(ICharacter character) {
                    if (null == character) return;
                    // end if
                    hashID = character.hashID;
                    HIT = character.info.characterData.HIT;
                    iscrit = MathTool.Random(0, 100f) < character.info.characterData.CRT ? true : false;
                    ATK = MathTool.Random(character.info.characterData.NATK, character.info.characterData.XATK) * (iscrit ? 2 : 1);
                    MGK = MathTool.Random(character.info.characterData.NMGK, character.info.characterData.XMGK) * (iscrit ? 2 : 1);
                } // end DamageData

                public DamageData(string hashID, IAttributeData data) {
                    if (null == data) return;
                    // end if
                    this.hashID = hashID;
                    HIT = data.HIT;
                    iscrit = MathTool.Random(0, 100f) < data.CRT ? true : false;
                    ATK = MathTool.Random(data.NATK, data.XATK) * (iscrit ? 2 : 1);
                    MGK = MathTool.Random(data.NMGK, data.XMGK) * (iscrit ? 2 : 1);
                } // end DamageData

                public DamageData(ICharacter character, ISKillData skillData) {
                    if (null == character) return;
                    // end if
                    hashID = character.hashID;
                    HIT = character.info.characterData.HIT;
                    iscrit = MathTool.Random(0, 100f) < character.info.characterData.CRT ? true : false;
                    ATK = MathTool.Random(character.info.characterData.NATK, character.info.characterData.XATK) * (iscrit ? 2 : 1);
                    MGK = MathTool.Random(character.info.characterData.NMGK, character.info.characterData.XMGK) * (iscrit ? 2 : 1);
                    if (null == skillData) return;
                    // end if
                    ATK = MathTool.Percent(ATK + skillData.ATK, skillData.ATKR);
                    MGK = MathTool.Percent(MGK + skillData.MGK, skillData.MGKR);
                    DEFR = skillData.DEFR;
                    RGSR = skillData.RGSR;
                } // end DamageData

                /// <summary>
                /// 必然暴击
                /// </summary>
                public void CertainCrit() {
                    if (iscrit) return;
                    // end if
                    iscrit = true;
                    ATK = ATK * 2;
                    MGK = MGK * 2;
                } // end CertainCrit
            } // end class DamageData
        } // end namespace Data
    } // end namespace ModelData
} // end namespace Solider 
