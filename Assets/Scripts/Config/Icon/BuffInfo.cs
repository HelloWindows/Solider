/*******************************************************************
 * FileName: BuffInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;

namespace Solider {
    namespace Config {
        namespace Icon {
            public class BuffInfo : IconInfo {
                public readonly string buffID; // 相同ID的 buff 只能同时存在一个
                public readonly bool isDebuff; // 是否是减益 buff (用来判断是否应该被净化)
                public readonly bool isPassive; // 是否是被动 buff (被动技能就是一个buff)
                public readonly bool removable; // 可以被去除 (有些buff可以被净化)
                public readonly int HOT;
                public readonly int MOT;
                public readonly float HPR;
                public readonly float MPR;
                public readonly float XHR;
                public readonly float XMR;
                public readonly float ATKR; // 物理攻击百分比
                public readonly float MGKR; // 魔法攻击百分比
                public readonly float DEFR; // 物理防御百分比
                public readonly float RGSR; // 魔法防御百分比
                public readonly float ASPR; // 攻速百分比
                public readonly float MSPR; // 移速百分比
                public readonly float HIT; // 命中率
                public readonly float AVD; // 闪避率
                public readonly float CRT; // 暴击率
                public readonly float LOT; // 持续时间

                public BuffInfo(JsonData data) {
                    id = (string)data["id"];
                    name = (string)data["name"];
                    spritepath = (string)data["spritepath"];
                    intro = (string)data["intro"];
                    JsonData property = data["buffinfo"];
                    buffID = (string)property["buffID"];
                    isDebuff = (bool)property["isDebuff"];
                    isPassive = (bool)property["isPassive"];
                    removable = (bool)property["removable"];
                    HOT = (int)property["HOT"];
                    MOT = (int)property["MOT"];
                    HPR = (float)property["HPR"];
                    MPR = (float)property["MPR"];
                    XHR = (float)property["XHR"];
                    XMR = (float)property["XMR"];
                    ATKR = (float)property["ATKR"];
                    MGKR = (float)property["MGKR"];
                    DEFR = (float)property["DEFR"];
                    RGSR = (float)property["RGSR"];
                    ASPR = (float)property["ASPR"];
                    MSPR = (float)property["MSPR"];
                    HIT = (float)property["HIT"];
                    AVD = (float)property["AVD"];
                    CRT = (float)property["CRT"];
                    LOT = (float)property["LOT"];
                } // end BuffInfo
            } // end class BuffInfo
        } // end namespace Icon 
    } // end namespace Config
} // end namespace Custom 
