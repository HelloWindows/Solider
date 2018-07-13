/*******************************************************************
 * FileName: EquipmentConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class EquipInfo {
            private static readonly StringBuilder infoBuilder = new StringBuilder();
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
                infoBuilder.Length = 0;
                infoBuilder.Append("<size=24>");
                switch (grade) {
                    case "A":
                        infoBuilder.Append("<color=#FFD700FF>");
                        infoBuilder.Append(name);
                        break;

                    case "B":
                        infoBuilder.Append("<color=#ADFF2FFF>");
                        infoBuilder.Append(name);
                        break;

                    case "C":
                        infoBuilder.Append("<color=#0000FFFF>");
                        infoBuilder.Append(name);
                        break;

                    default:
                        infoBuilder.Append("<color=#FFFFFFFF>");
                        infoBuilder.Append(name);
                        break;
                } // end switch
                infoBuilder.Append("</color>");
                infoBuilder.Append("</size>");
                infoBuilder.Append('\n');
                infoBuilder.Append('\n');
                infoBuilder.Append("<size=18>");

                if (role != "all" && role != PlayerManager.roleType) {
                    infoBuilder.Append("<color=#FF0000FF>");

                } else {
                    infoBuilder.Append("<color=#FFFFFFFF>");
                }// end 

                switch (role) {
                    case "Shooter":
                        infoBuilder.Append("射手");
                        break;

                    case "Solider":
                        infoBuilder.Append("战士");
                        break;

                    default:
                        infoBuilder.Append("全部");
                        break;
                } // end switch
                infoBuilder.Append("</color>");
                infoBuilder.Append("</size>");
                infoBuilder.Append('\n');
                infoBuilder.Append('\n');
                infoBuilder.Append("<size=20>");

                if (property.attmin != 0 || property.attmax != 0) {
                    infoBuilder.Append("战斗力：");
                    infoBuilder.Append(property.attmin);
                    infoBuilder.Append(" - ");
                    infoBuilder.Append(property.attmax);
                    infoBuilder.Append('\n');
                } // end if

                if (property.def != 0) {
                    infoBuilder.Append("防御力：");
                    infoBuilder.Append(property.def);
                    infoBuilder.Append('\n');
                } // end if

                if (property.attspeed != 0) {
                    infoBuilder.Append("攻速：");
                    infoBuilder.Append(property.attspeed);
                    infoBuilder.Append('\n');
                } // end if

                if (property.movspeed != 0) {
                    infoBuilder.Append("移速：");
                    infoBuilder.Append(property.movspeed);
                    infoBuilder.Append('\n');
                } // end if

                if (property.crit != 0) {
                    infoBuilder.Append("暴击率：");
                    infoBuilder.Append(property.crit);
                    infoBuilder.Append('\n');
                } // end if

                if (property.clip != 0) {
                    infoBuilder.Append("弹夹：");
                    infoBuilder.Append(property.clip);
                    infoBuilder.Append(" 发");
                    infoBuilder.Append('\n');
                } // end if
                infoBuilder.Append("</size>");
                infoBuilder.Append('\n');
                infoBuilder.Append('\n');
                infoBuilder.Append("<size=16>");
                infoBuilder.Append(intro);
                infoBuilder.Append("</size>");
                return infoBuilder.ToString();
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