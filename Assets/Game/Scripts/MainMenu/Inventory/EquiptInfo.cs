using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquiptInfo : MonoBehaviour {

    public Button closeBtn;
    public Button equipBtn;
    public Button upgradeBtn;

    public Image equiptIcon;
    public Text equiptName;
    public Text quality;
    public Text attack;
    public Text HP;
    public Text power;
    public Text desc;

    public void UpdateShow(InventoryItem item)
    {
        if (item.GetInventroy.InventoryTYPE != InventoryType.Equip)
        {
            Debug.LogWarning("this is not an equipt");
            return;
        }

        equiptIcon.overrideSprite = Resources.Load<Sprite>(item.GetInventroy.Icon);
        equiptName.text = item.GetInventroy.Name;
        quality.text = item.GetInventroy.Quality.ToString();
        attack.text = item.GetInventroy.Attack.ToString();
        HP.text = item.GetInventroy.HP.ToString();
        power.text = item.GetInventroy.Power.ToString();
        desc.text = item.GetInventroy.Des;        
    }

    private void Awake()
    {
        closeBtn.onClick.AddListener(() => gameObject.SetActive(false));
    }
}
