using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public List<InventoryItemUI> itUIList = new List<InventoryItemUI>();
    public Text itemCount;
    public Text price;
    public Button sellBtn;
    public Button tidyBtn;

    private void Awake()
    {
        InventoryManager.Instance.OnInventoryChanged += this.OnInventoryChanged;
    }

    private void OnDestroy()
    {
        InventoryManager.Instance.OnInventoryChanged -= this.OnInventoryChanged;
    }

    private void OnInventoryChanged()
    {
        UpdateShow();
    }

    private void UpdateShow()
    {
        int count = InventoryManager.Instance.inventoryItemList.Count;
        itemCount.text = count + "/32";
        price.text = "";

        for (int i = 0; i < count; i++)
        {
            InventoryItem item = InventoryManager.Instance.inventoryItemList[i];
            itUIList[i].SetInventoryItem(item);
        }

        for (int j = count; j < itUIList.Count; j++)
        {
            itUIList[j].Clear();          
        }
    }
}
