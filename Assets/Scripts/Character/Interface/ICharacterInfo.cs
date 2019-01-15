/*******************************************************************
 * FileName: ICharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.ModelData.Interface;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterInfo {
                /// <summary>
                /// 锁定的角色
                /// </summary>
                ICharacter lockCharacter { get; }
                /// <summary>
                /// 锁定角色
                /// </summary>
                /// <param name="hashID"> 锁定的角色 </param>
                void LockCharacter(ICharacter character);
                /// <summary>
                /// 角色数据
                /// </summary>
                ICharacterData characterData { get; }
                /// <summary>
                /// 遭受攻击
                /// </summary>
                /// <param name="data"></param>
                void UnderAttack(IDamageData data);
                /// <summary>
                /// 显示或隐藏血条
                /// </summary>
                void SwitchHpBar(bool isShow);
                /// <summary>
                /// 复活
                /// </summary>
                void Revive();                
            } // end interface ICharacterInfo 
        } // end namespace Interface
    } // end namespace Character 
} // end namespace Solider