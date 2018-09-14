using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour {

    public Text goldTxt;
    public Text diamondTxt;
    public Button increaseGoldBtn;
    public Button increaseDiamondBtn;

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
            case PlayerInfoType.Diamond:              
            case PlayerInfoType.Gold:          
            case PlayerInfoType.All:
                UpdateInfoShow();
                break;
            default:
                break;
        }
    }

    private void UpdateInfoShow()
    {
        goldTxt.text = PlayerInfo.Instance.Gold.ToString();
        diamondTxt.text = PlayerInfo.Instance.Diamond.ToString();
    }
}