/*******************************************************************
 * FileName: DemonBossChase.cs
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

namespace Solider.Character.Boss {

    public class DemonBossChase : NPCChase {
        private float timer;
        private float interval;
        private ICharacterSkill skill;
        private ISkillModle modle;

        public DemonBossChase(ISkillCharacter character) : base(character) {
            skill = character.skill;
            if (null == skill) DebugTool.LogError(GetType() + " skill is null!");
            // end if
        } // end DemonBossChase

        public override void DoBeforeEntering() {
            timer = 0;
            interval = Random.Range(1f, 5f);
            base.DoBeforeEntering();
            modle = skill.GetSkillModle(DemonSkill_1.ID);
        } // end DoBeforeEntering

        public override void Reason() {
            if (null != character.info.lockCharacter && null != modle && modle.isCD) {
                timer += Time.deltaTime;
                if (timer > interval && 
                    Vector3.Distance(character.info.lockCharacter.position, character.position) < 4f && 
                    skill.CastSkill(DemonSkill_1.ID)) return;
                // end if
            } // end if
            base.Reason();
        } // end Reason
    } // end class SfixBossChase
} // end namespace Solider.Character.Boss
