using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour {

    private Image img;
    private Text count;
    private InventoryItem item;
    private Button itemBtn;

    public int ItemID
    {
        get;set;
    }

    public bool isEmpty
    {
        get;set;
    }

    private void Awake()
    {
        itemBtn = transform.GetComponent<Button>();
        itemBtn.onClick.AddListener(OnPressedItem);
    }

    private void OnPressedItem()
    {
        if (isEmpty)
        {
            InventoryUI.Instance.ClearPrice();
            return;
        }
           
        transform.GetComponentInParent<Knapsack>().OnPressed(item, true, ItemID);
        InventoryUI.Instance.UpdatePrice(item, ItemID);
    }

    private Image Img
    {
        get
        {
            if (img == null)
            {
                img = transform.Find("ItemImg").GetComponentInChildren<Image>();
                //Debug.Log(img.name);
            }

            return img;
        }

    }

    private Text Count
    {
        get
        {
            if (count == null)
            {
                count = transform.GetComponentInChildren<Text>();
            }
            return count;
        }
    }

    public void SetInventoryItem(InventoryItem it)
    {
        if (it == null)
            return;

        item = it;
        //Debug.Log(it.Inventroy.Icon);
        Img.overrideSprite = Resources.Load<Sprite>(it.GetInventroy.Icon);
        if (item.Count <= 1)
        {
            Count.text = "";
        }
        else
        {
            Count.text = item.Count.ToString();
        }

        isEmpty = false;
    }

    public void Clear()
    {
        Img.overrideSprite = Resources.Load<Sprite>("ItemIcon/bg_Equipt");
        Count.text = "";
        isEmpty = true;
    }

    public void UpdateItemCountShow(int value)
    {
        if (value <= 1)
        {
            Count.text = "";
        }
        else
        {
            Count.text = value.ToString();
        }
    }
  
   
}
