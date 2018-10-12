using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusPanel : MonoBehaviour {

    public static PlayerStatusPanel Instance;

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
    public Text toughenRecoverAllTimeTxt;
    public Button changeNameBtn;
    public Button closeBtn;

    public GameObject changeNamePanel;
    public Button cancelBtn;
    public Button confirmBtn;
    public InputField newNameInput;

    [SerializeField]
    private Sprite[] headImgs;

    private void Awake()
    {
        Instance = this;
        PlayerInfo.Instance.OnPlayerInfoChanged += this.OnPlayerInfoChanged;
    }

    private void OnDestroy()
    {
        PlayerInfo.Instance.OnPlayerInfoChanged -= this.OnPlayerInfoChanged;
    }

    private void Start()
    {
        changeNamePanel.SetActive(false);
        closeBtn.onClick.AddListener(() => gameObject.SetActive(false));
        changeNameBtn.onClick.AddListener(() => changeNamePanel.SetActive(true));
        cancelBtn.onClick.AddListener(() => changeNamePanel.SetActive(false));
        confirmBtn.onClick.AddListener(() => {
            string newName = newNameInput.text.ToString().Trim();
            //服务器校验TODO

            PlayerInfo.Instance.ChangeName(newName);
            changeNamePanel.SetActive(false);
        });
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
        toughenTxt.text = PlayerInfo.Instance.Toughen + "/50";
        //energyRecoverTimeTxt.text
        //energyRecoverAllTimeTxt.text
        //toughenRecoverTimeTxt.text
        //touchenRecoverAllTimeTxt.text
    }

    private int energy;
    private int toughen;
    private float energyTimer = 0f;
    private float toughenTimer = 0f;

    private void Update()
    {
        UpdateTimerTxt();
    }

    private void UpdateTimerTxt()
    {
        energy = PlayerInfo.Instance.Energy;
        toughen = PlayerInfo.Instance.Toughen;

        if (energy < 100)
        {
            energyTimer += Time.deltaTime;
            if (energyTimer >= 60)
            {
                energyTimer -= 60;
                PlayerInfo.Instance.Energy += 1;                
            }

            int remainTimer = 60 - (int)energyTimer;

            string ss = remainTimer >= 10.0f ? remainTimer.ToString() : "0" + remainTimer.ToString();
            energyRecoverTimeTxt.text = "00:00:" + ss;

            int remainEnergy = 99 - PlayerInfo.Instance.Energy;
            energyRecoverAllTimeTxt.text = "0" + (remainEnergy / 60).ToString() + ":" + ((remainEnergy % 60) > 9 ? (remainEnergy % 60).ToString() : "0" + (remainEnergy % 60).ToString("F0")) + ":" + ss;
        }
        else
        {
            energyTimer = 0f;
            energyRecoverTimeTxt.text = "00:00:00";
            energyRecoverAllTimeTxt.text = "00:00:00";
        }

        if (toughen < 50)
        {
            toughenTimer += Time.deltaTime;
            if (toughenTimer >= 120)
            {
                toughenTimer -= 120;
                PlayerInfo.Instance.Toughen += 1;                
            }

            int remainTimerT = 120 - (int)toughenTimer;

            string mmT = "0" + (remainTimerT / 60).ToString();
            string ssT = (remainTimerT % 60) >= 10.0f ? (remainTimerT % 60).ToString() : "0" + (remainTimerT % 60).ToString();
            toughenRecoverTimeTxt.text = "00:" + mmT + ":" + ssT;

            int remainToughMinutes = (49 - PlayerInfo.Instance.Toughen)*2 + remainTimerT / 60;
            Debug.Log(remainToughMinutes);

            toughenRecoverAllTimeTxt.text = "0" + (remainToughMinutes / 60).ToString() + ":" + ((remainToughMinutes % 60) > 9 ? (remainToughMinutes % 60).ToString() : "0" + (remainToughMinutes % 60).ToString()) + ":" + ssT;
        }
        else
        {
            toughenTimer = 0f;
            toughenRecoverTimeTxt.text = "00:00:00";
            toughenRecoverAllTimeTxt.text = "00:00:00";
        }

        energyTxt.text = PlayerInfo.Instance.Energy + "/100";
        toughenTxt.text = PlayerInfo.Instance.Toughen + "/50";
    }

}
