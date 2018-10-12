using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {

    public Button closeBtn;
    public Button useBtn;
    public Button batchUseBtn;
    public Text batchUseTxt;

    public Image itemIcon;
    public Text itemName;
    public Text itemType;
    public Text itemDesc;

    public void UpdateShow(InventoryItem item)
    {
        itemIcon.overrideSprite = Resources.Load<Sprite>(item.GetInventroy.Icon);
        itemName.text = item.GetInventroy.Name;        
        itemDesc.text = item.GetInventroy.Des;
        batchUseTxt.text = "批量使用(" + item.Count + ")";
        switch (item.GetInventroy.InventoryTYPE)
        {           
            case InventoryType.Drug:
                itemType.text = "药品";
                break;
            case InventoryType.Box:
                itemType.text = "宝箱";
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        closeBtn.onClick.AddListener(() => gameObject.SetActive(false));

    }
}
