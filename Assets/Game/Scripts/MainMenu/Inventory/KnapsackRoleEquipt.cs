using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnapsackRoleEquipt : MonoBehaviour {

    private Image img;
    private Button equiptBtn;
    private InventoryItem item;
    public bool isEquiped
    {
        get;set;
    }
    public int HP
    {
        get
        {
            return isEquiped ? item.GetInventroy.HP : 0;
        }
    }

    public int Attack
    {
        get
        {
            return isEquiped ? item.GetInventroy.Attack : 0;
        }
    } 

    private Image Img
    {
        get
        {
            if (img == null)
            {
                img = transform.GetComponent<Image>();
            }

            return img;
        }
    }

    private void Awake()
    {
        equiptBtn = GetComponent<Button>();
        equiptBtn.onClick.AddListener(PressEquipt);
    }

    private void PressEquipt()
    {
        if (isEquiped)
        {
            GetComponentInParent<Knapsack>().OnPressed(item, false, -1); //-1表示已经装备
        }
    }

    public void UpdateImgByInventoryItem(InventoryItem item)
    {
        if (item == null)
            return;
        this.item = item;
        Img.overrideSprite = Resources.Load<Sprite>(item.GetInventroy.Icon);
        isEquiped = true;
    }

    public void Clear()
    {
        item = null;
        Img.overrideSprite = Resources.Load<Sprite>("ItemIcon/bg_Equipt");
        isEquiped = false;
        //print("clear  000 " + name);
    }
}
