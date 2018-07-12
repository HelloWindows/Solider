/*******************************************************************
 * FileName: EquipmentConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class EquipInfo {
            public string id { get; private set; }
            public string name { get; private set; }
            public string grade { get; private set; }
            public string role { get; private set; }
            public string spritepath { get; private set; }
            public string intro { get; private set; }
            public EquipProperty property { get; private set; }

            public EquipInfo() {
                property = new EquipProperty();
            } // end EquipInfo

            public void SetID(string id) { this.id = id; } // end SetID
            public void SetName(string name) { this.name = name; } // end SetName
            public void SetGrade(string grade) { this.grade = grade; } // end SetGrade
            public void SetRole(string role) { this.role = role; } // end SetRole
            public void SetSpritepath(string spritepath) { this.spritepath = spritepath; } // end SetSpritepaht
            public void SetIntro(string intro) { this.intro = intro; } // end SetIntro

            public void SetAttmin(int attmin) { property.SetAttmin(attmin); } // end SetAttmin
            public void SetAttmax(int attmax) { property.SetAttmax(attmax); } // end SetAttmax
            public void SetDef(int def) { property.SetDef(def); } // end SetDef
            public void SetAttspeed(float attspeed) { property.SetAttspeed(attspeed); } // end SetAttspeed
            public void SetMovspeed(float movspeed) { property.SetMovspeed(movspeed); } // end SetMovspeed
            public void SetCrit(float crit) { property.SetCrit(crit); } // end SetCrit
            public void SetClip(float clip) { property.SetClip(clip); } // end SetClip

            public override string ToString() {
                return "EquipmentInfo: " + '\n' +
                    "id: " + id + '\n' +
                    "name: " + name + '\n' +
                    "grade: " + grade + '\n' +
                    "role: " + role + '\n' +
                    "spritepaht: " + spritepath + '\n' +
                    "intro: " + intro + '\n' +
                    "******** property *******" + '\n' +
                    "attmin: " + property.attmin + '\n' +
                    "attmax: " + property.attmax + '\n' +
                    "def: " + property.def + '\n' +
                    "attspeed: " + property.attspeed + '\n' +
                    "movspeed: " + property.movspeed + '\n' +
                    "crit: " + property.crit + '\n' +
                    "clip: " + property.clip;
            } // end ToString
        } // end class EquipmentInfo 

        public class EquipProperty {
            public int attmin { get; private set; }
            public int attmax { get; private set; }
            public int def { get; private set; }
            public float attspeed { get; private set; }
            public float movspeed { get; private set; }
            public float crit { get; private set; }
            public float clip { get; private set; }

            public void SetAttmin(int attmin) { this.attmin = attmin; } // end SetAttmin
            public void SetAttmax(int attmax) { this.attmax = attmax; } // end SetAttmax
            public void SetDef(int def) { this.def = def; } // end SetDef
            public void SetAttspeed(float attspeed) { this.attspeed = attspeed; } // end SetAttspeed
            public void SetMovspeed(float movspeed) { this.movspeed = movspeed; } // end SetMovspeed
            public void SetCrit(float crit) { this.crit = crit; } // end SetCrit
            public void SetClip(float clip) { this.clip = clip; } // end SetClip
        } // end class EquipProperty
    } // end namespace Config
} // end namespace Custom