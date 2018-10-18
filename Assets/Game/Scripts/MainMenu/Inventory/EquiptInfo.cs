using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquiptInfo : MonoBehaviour {

    public Button closeBtn;
    public Button equipBtn;
    public Button upgradeBtn;

    public Text equipTxt;
    public Image equiptIcon;
    public Text equiptName;
    public Text quality;
    public Text attack;
    public Text HP;
    public Text equiptLevel;
    public Text power;
    public Text desc;
    public Prompt prompt;

    private InventoryItem item;
    private bool selfIsOnLeft;
    private int itemId;

    public void UpdateShow(InventoryItem item, bool isRight, int itemId)
    {
        selfIsOnLeft = isRight;
        this.item = item;
        this.itemId = itemId;

        if (selfIsOnLeft)
        {
            equipTxt.text = "装备";
        }
        else
        {
            equipTxt.text = "卸下";
        }        

        equiptIcon.overrideSprite = Resources.Load<Sprite>(item.GetInventroy.Icon);
        equiptName.text = item.GetInventroy.Name;
        quality.text = item.GetInventroy.Quality.ToString();
        attack.text = item.GetInventroy.Attack.ToString();
        HP.text = item.GetInventroy.HP.ToString();
        equiptLevel.text = item.Level.ToString();
        power.text = item.GetInventroy.Power.ToString();
        desc.text = item.GetInventroy.Des;        
    }

    private void Awake()
    {
        closeBtn.onClick.AddListener(Close);
        equipBtn.onClick.AddListener(EquitOrUnequip);
        upgradeBtn.onClick.AddListener(Upgrade);
    }

    private void EquitOrUnequip()
    {
        if (item == null)
            return;

        if (selfIsOnLeft)
        {
            //装备          
            PlayerInfo.Instance.PutOnEquip(item, itemId);
        }
        else
        {
            //卸下
            PlayerInfo.Instance.PutOffEquip(item);
        }
        Close();
    }

    private void Upgrade()
    {
        if (PlayerInfo.Instance.UpgradeEquipt(item))
        {
            attack.text = item.GetInventroy.Attack.ToString();
            HP.text = item.GetInventroy.HP.ToString();
            equiptLevel.text = item.Level.ToString();
            power.text = item.GetInventroy.Power.ToString();
        }
        else
        {
            prompt.gameObject.SetActive(true);
            prompt.Fade();
        }
    }

    private void Close()
    {
        item = null;
        gameObject.SetActive(false);
    }
    
}
