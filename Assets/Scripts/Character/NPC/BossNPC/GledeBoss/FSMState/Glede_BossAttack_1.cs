/*******************************************************************
 * FileName: Glede_BossAttack_1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Character.Skill;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Glede_BossAttack_1 : Melee_NPCAttack_1 {
                private ICharacterSkill skill;

                public Glede_BossAttack_1(ISkillCharacter character) : base(character) {
                    skill = character.skill;
                    if (null == skill) DebugTool.LogError(GetType() + " skill is null!");
                    // end if
                } // end Glede_BossAttack_1

                public override void DoBeforeEntering() {
                    if (skill.GetSkillModle(GledeSkill_1.ID).isCD && UnityEngine.Random.Range(0, 2) < 1) {
                        if (skill.CastSkill(GledeSkill_1.ID)) return;
                        // end if
                    } // end if
                    base.DoBeforeEntering();
                } // end if
            } // end class Glede_BossAttack_1
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider
