using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusPanel : MonoBehaviour {

    public Image headImg;
    public Text playerName;
    public Text playerLevel;
    public Text powerTxt;
    public Slider expSlider;
    public Text expTxt;
    public Text diamondTxt;
    public Text goldTxt;
    public Text energyTxt;
    public Text toughenTxt;
    public Text energyRecoverTimeTxt;
    public Text energyRecoverAllTimeTxt;
    public Text toughenRecoverTimeTxt;
    public Text touchenRecoverAllTimeTxt;
    public Button changeNameBtn;
    public Button closeBtn;

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
        UpdateInfoShow();
    }

    private void UpdateInfoShow()
    {
        headImg.overrideSprite = headImgs[PlayerInfo.Instance.HeadPortraitID];
        playerName.text = PlayerInfo.Instance.Name;
        playerLevel.text = PlayerInfo.Instance.Level.ToString();
        powerTxt.text = PlayerInfo.Instance.Power.ToString();
        int requiredExp = GameController.GetRequiredExpByLevel(PlayerInfo.Instance.Level + 1);
        expSlider.value = PlayerInfo.Instance.Exp *1.0f / requiredExp;
        expTxt.text = PlayerInfo.Instance.Exp + "/" + requiredExp.ToString();
        diamondTxt.text = PlayerInfo.Instance.Diamond.ToString();
        goldTxt.text = PlayerInfo.Instance.Gold.ToString();
        energyTxt.text = PlayerInfo.Instance.Energy + "/100";
        toughenTxt.text = PlayerInfo.Instance.Toughen + "/50";
        //energyRecoverTimeTxt.text
        //energyRecoverAllTimeTxt.text
        //toughenRecoverTimeTxt.text
        //touchenRecoverAllTimeTxt.text
    }

}
