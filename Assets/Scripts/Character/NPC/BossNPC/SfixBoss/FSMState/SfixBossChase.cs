/*******************************************************************
 * FileName: SfixBossChase.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Character.NPC;
using Solider.Character.Skill;
using Solider.Model.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Boss {
            public class SfixBossChase : NPCChase {
                private float timer;
                private float interval;
                private ICharacterSkill skill;
                private ISkillModle modle;

                public SfixBossChase(ISkillCharacter character) : base(character) {
                    skill = character.skill;
                    if (null == skill) DebugTool.LogError(GetType() + " skill is null!");
                    // end if
                } // end SfixBossChase

                public override void DoBeforeEntering() {
                    timer = 0;
                    interval = Random.Range(1f, 5f);
                    base.DoBeforeEntering();
                    modle = skill.GetSkillModle(SfixSkill_1.ID);
                } // end DoBeforeEntering

                public override void Reason() {
                    if (null != modle && modle.isCD) {
                        timer += Time.deltaTime;
                        if (timer > interval) {
                            if (skill.CastSkill(SfixSkill_1.ID)) return;
                            // end if
                        } // end if
                    } // end if
                    base.Reason();
                } // end Reason
            } // end class SfixBossChase
        } // end namespace Boss
    } // end namespace Character 
} // end namespace Solider
