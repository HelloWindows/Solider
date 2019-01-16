/*******************************************************************
 * FileName: NPCharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Solider.Character.Interface;
using Solider.ModelData.Character;
using Solider.ModelData.Data;
using Solider.ModelData.Interface;
using Solider.Widget;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPCharacterInfo : CharacterInfo {
                private ICharacter character;
                private HPBar hpBar;

                public NPCharacterInfo(string name, ICharacter character) : base() {
                    this.character = character;
                    initArribute = character.config.initAttribute;
                    m_charcterData = new CharacterData(name);
                    CheckAttributeData(CenterEvent.ReloadEquip);
                    m_charcterData.Plus(m_selfTreat);
                    character.center.AddListener(CheckAttributeData);
                } // end MainCharacterInfo

                public override void Update() {
                    base.Update();
                    if (null == hpBar) return;
                    // end if
                    hpBar.SetFillAmount(System.Convert.ToSingle(m_charcterData.HP) / m_charcterData.XHP);
                } // end Update

                private void CheckAttributeData(CenterEvent type) {
                    if (CenterEvent.BuffChange != type && CenterEvent.ReloadEquip != type) return;
                    // end if
                    m_charcterData.Init(initArribute);
                } // end CheckAttributeData

                public override void UnderAttack(IDamageData data) {
                    IRealData realData = new RealData(data);
                    m_charcterData.Minus(realData);
                    Vector2 screenPoint = SceneManager.mainCamera.camera.WorldToScreenPoint(character.helpTransform.position);
                    Vector2 hud_pos;
                    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(SceneManager.mainCanvas.HUD_rectTRansform, screenPoint,
                        SceneManager.mainCanvas.camera, out hud_pos)) {
                        HUD_Damage hud = InstanceMgr.GetObjectManager().GetGameObject<HUD_Damage>("hud_damage");
                        hud.SetNumber(realData.HP);
                        hud.transform.SetParent(SceneManager.mainCanvas.HUD_rectTRansform, false);
                        hud.transform.localPosition = hud_pos;
                        hud.gameObject.SetActive(true);
                    } // end if
                    if (null != lockCharacter) return;
                    // end if
                    if (data.hashID == SceneManager.mainCharacter.hashID) {
                        LockCharacter(SceneManager.mainCharacter);
                        return;
                    } // end if
                    ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(data.hashID);
                    if (null != npc) {
                        LockCharacter(npc);
                    } // end if
                } // end UnderAttack

                public override void SwitchHpBar(bool isShow) {
                    if (isShow) {
                        if (null == hpBar) {
                            hpBar = InstanceMgr.GetObjectManager().GetGameObject<HPBar>("hp_bar");
                            hpBar.transform.SetParent(character.helpTransform, false);
                            hpBar.gameObject.SetActive(true);
                        } // end if
                    } else {
                        if (null == hpBar) return;
                        // end if
                        hpBar.Recycling();
                        hpBar = null;
                    } // end if
                } // end SwitchHpBar

                public override void Dispose() {
                    if (null != hpBar) {
                        hpBar.Recycling();
                        hpBar = null;
                    } // end if
                    character.center.RemoveListener(CheckAttributeData);
                } // end Dispose
            } // end class NPCharacterInfo
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 