/*******************************************************************
 * FileName: UIMainCharacterInfoPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Solider.ModelData.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIMainCharacterInfoPanel : UIBehaviour, IPointerDownHandler, IPointerUpHandler {
                private Text nameText;
                private Image hpImage;
                private Text hpText;
                private Image mpImage;
                private Text mpText;
                private GameObject infoPanelGo;
                private Text infoText;

                protected override void Awake() {
                    nameText = transform.Find("Name").GetComponent<Text>();
                    hpImage = transform.Find("HPSlider/Image").GetComponent<Image>();
                    hpText = transform.Find("HPSlider/Text").GetComponent<Text>();
                    mpImage = transform.Find("MPSlider/Image").GetComponent<Image>();
                    mpText = transform.Find("MPSlider/Text").GetComponent<Text>();
                    infoPanelGo = transform.Find("InfoPanel").gameObject;
                    infoText = infoPanelGo.transform.Find("InfoText").GetComponent<Text>();
                    infoPanelGo.SetActive(false);
                } // end Awake

                public void Show() {
                    ICharacterData data = SceneManager.mainCharacter.info.characterData;
                    nameText.text = data.name;
                    hpText.text = data.HP + "/" + data.XHP;
                    hpImage.fillAmount = System.Convert.ToSingle(data.HP) / data.XHP;
                    mpText.text = data.MP + "/" + data.XMP;
                    mpImage.fillAmount = System.Convert.ToSingle(data.MP) / data.XMP;
                } // end Show

                public void OnPointerDown(PointerEventData eventData) {
                    infoText.text = SceneManager.mainCharacter.info.characterData.ToString();
                    infoPanelGo.SetActive(true);
                } // end OnPointerDown

                public void OnPointerUp(PointerEventData eventData) {
                    infoPanelGo.SetActive(false);
                } // end OnPointerUp
            } // end class UIMainCharacterInfoPanel 
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider