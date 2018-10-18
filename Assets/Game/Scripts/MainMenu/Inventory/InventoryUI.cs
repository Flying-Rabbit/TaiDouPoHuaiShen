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
    public GameObject itemInfoGO;
    public GameObject equiptInfoGo;
    public static InventoryUI Instance;

    private InventoryItem item;
    private int itemID;

    private void Awake()
    {
        Instance = this;
        KnapsackManager.Instance.OnInventoryChanged += this.OnInventoryChanged;
        sellBtn.onClick.AddListener(Sell);
        tidyBtn.onClick.AddListener(Tidy);
    }

    private void OnDestroy()
    {
        KnapsackManager.Instance.OnInventoryChanged -= this.OnInventoryChanged;
    }

    private void Start()
    {
        for (int i = 0; i < itUIList.Count; i++)
        {
            itUIList[i].ItemID = i;            
        }
    }

    private void OnInventoryChanged()
    {
        UpdateShow();
    }

    private void UpdateShow()
    {
        int count = KnapsackManager.inventoryItemList.Count;
        itemCount.text = count + "/32";
        price.text = "";

        for (int i = 0; i < count; i++)
        {
            InventoryItem item = KnapsackManager.inventoryItemList[i];
            itUIList[i].SetInventoryItem(item);
        }

        for (int j = count; j < itUIList.Count; j++)
        {
            itUIList[j].Clear();          
        }
    }

    public void UpdatePrice(InventoryItem item, int itemID)
    {
        if (item != null)
        {
            this.item = item;
            this.itemID = itemID;
            price.text = item.GetInventroy.Price.ToString();
        }       
    }

    public void ClearPrice()
    {
        this.item = null;
        price.text = "";
        UpdateCount();
    }

    public void UpdateCount()
    {
        itemCount.text = KnapsackManager.inventoryItemList.Count + "/32";
    }

    private void Sell()
    {
        if (item == null || item.Count < 1)
        {
            ClearPrice();
            return;
        }

        if (item.GetInventroy.InventoryTYPE == InventoryType.Equip)
        {
            if (item.IsDressed)
            {
                return;
            }
        }

        PlayerInfo.Instance.ChangeGold(item.GetInventroy.Price);

        if (item.Count == 1)
        {
            itUIList[itemID].Clear();
            KnapsackManager.inventoryItemList.Remove(item);
            itemInfoGO.SetActive(false);
            equiptInfoGo.SetActive(false);
            ClearPrice();
        }
        else
        {
            item.Count -= 1;
            itUIList[itemID].UpdateItemCountShow(item.Count);
        }        
    }

    private void Tidy()
    {
        UpdateShow();
        itemInfoGO.SetActive(false);
        equiptInfoGo.SetActive(false);
    }

    public void UseItem(int num, InventoryItem item, int itemID)
    {
        item.Count -= num;

        if (item.GetInventroy.InfoTYPE == PlayerInfoType.Energy)
        { 
            PlayerInfo.Instance.ChangeEnergy(num * item.GetInventroy.ApplyValue);
        }

        if (item.Count > 0)
        {
            itUIList[itemID].SetInventoryItem(item);
        }
        else
        {
            KnapsackManager.inventoryItemList.Remove(item);
            itUIList[itemID].Clear();
            ClearPrice();
            UpdateCount();
        }
    }
}
