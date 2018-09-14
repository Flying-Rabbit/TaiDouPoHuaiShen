using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour {

    public Image headImg;
    public Text playerNameTxt;
    public Text playerLevelTxt;    
    public Button increaseEnergyBtn;
    public Button increaseToughenBtn;
    public Slider energySlider;
    public Slider toughenSlider;
    public Text energyTxt;
    public Text toughenTxt;

    [SerializeField]
    private Sprite[] headImgs;

    private void Awake()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }

    private void OnDestroy()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    private void OnPlayerInfoChanged(PlayerInfoType type)
    {
        switch (type)
        {
            case PlayerInfoType.Name:               
            case PlayerInfoType.HeadPortrait:                
            case PlayerInfoType.Level: 
            case PlayerInfoType.Energy:           
            case PlayerInfoType.Toughen:             
            case PlayerInfoType.All:
                UpdateInfoShow();
                break;
            default:
                break;
        }
    }

    private void UpdateInfoShow()
    {
        headImg.overrideSprite = headImgs[PlayerInfo.Instance.HeadPortraitID];
        playerNameTxt.text = PlayerInfo.Instance.Name;
        playerLevelTxt.text = PlayerInfo.Instance.Level.ToString();
        energySlider.value = PlayerInfo.Instance.Energy * 1.0f / 100f;
        energyTxt.text = PlayerInfo.Instance.Energy + "/100";
        toughenSlider.value = PlayerInfo.Instance.Toughen * 1.0f / 50f;
        toughenTxt.text = PlayerInfo.Instance.Toughen + "/50";
    }
}