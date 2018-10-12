using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour {

    private Image img;
    private Text count;
    private InventoryItem item;
    private Button itemBtn;

    private void Awake()
    {
        itemBtn = transform.GetComponent<Button>();
        itemBtn.onClick.AddListener(OnPressedItem);
    }

    private void OnPressedItem()
    {
        transform.GetComponentInParent<Knapsack>().OnPressed(item, true);       
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
    }

    public void Clear()
    {
        Img.overrideSprite = Resources.Load<Sprite>("ItemIcon/bgbag");
        Count.text = "";
    }
}
