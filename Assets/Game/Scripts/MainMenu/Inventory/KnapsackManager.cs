using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackManager : MonoBehaviour {

    public static KnapsackManager Instance;
    public TextAsset listInfo;
    public GameObject knapsackGo;
    public static Dictionary<int, Inventory> inventoryDict = new Dictionary<int, Inventory>();    
    public static List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    public Action OnInventoryChanged;
    private bool hasReadItems = false;
    private void ReadInventoryInfo()
    {
        //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 
        //售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
        string str = listInfo.ToString();
        string[] itemAry = str.Split('\n');
        foreach(string itemStr in itemAry)
        {         
            string[] attrAry = itemStr.Split('|');
            Inventory inventory = new Inventory();
            inventory.ID = int.Parse(attrAry[0]);
            inventory.Name = attrAry[1];
            inventory.Icon = attrAry[2];
            inventory.Price = int.Parse(attrAry[5]);
            inventory.Des = attrAry[13];

            if (attrAry[3] == "Equip")
            {
                inventory.InventoryTYPE = InventoryType.Equip;
                switch (attrAry[4])
                {
                    case "Helm":
                        inventory.EquipTYPE = EquipType.Helmet;
                        break;
                    case "Cloth":
                        inventory.EquipTYPE = EquipType.Cloth;
                        break;
                    case "Shoes":
                        inventory.EquipTYPE = EquipType.Shoes;
                        break;
                    case "Weapon":
                        inventory.EquipTYPE = EquipType.Weapon;
                        break;
                    case "Necklace":
                        inventory.EquipTYPE = EquipType.Necklace;
                        break;
                    case "Bracelet":
                        inventory.EquipTYPE = EquipType.Bracelet;
                        break;
                    case "Ring":
                        inventory.EquipTYPE = EquipType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipTYPE = EquipType.Wing;
                        break;
                }

                
                inventory.StarLevel = int.Parse(attrAry[6]);
                inventory.Quality = int.Parse(attrAry[7]);
                inventory.Attack = int.Parse(attrAry[8]);
                inventory.HP = int.Parse(attrAry[9]);
                inventory.Power = int.Parse(attrAry[10]);
            }
            else if (attrAry[3] == "Drug")
            {
                inventory.InventoryTYPE = InventoryType.Drug;               
                inventory.InfoTYPE = PlayerInfoType.Energy;
                inventory.ApplyValue = int.Parse(attrAry[12]);
            }
            else if (attrAry[3] == "Box")
            {
                inventory.InventoryTYPE = InventoryType.Box;
            }
            
            inventoryDict.Add(inventory.ID, inventory);
        }
        
    }

    private void ReadInventoryItemInfo()
    {
        //TODO 链接服务器读取当前角色拥有的物品信息

        //随机生成角色拥有的物品
        for (int i = 0; i < 20; i++)
        {
            int id = UnityEngine.Random.Range(1001, 1020);

            Inventory inventory = null;
            inventoryDict.TryGetValue(id, out inventory);

            if (inventory == null)
            {
                Debug.LogWarning("no such id");
                return;
            }

            if (inventory.InventoryTYPE == InventoryType.Equip)
            {
                InventoryItem ii = new InventoryItem();
                ii.GetInventroy = inventory;
                ii.Level = UnityEngine.Random.Range(1, 10);
                ii.Count = 1;
                ii.IsDressed = false;
                inventoryItemList.Add(ii);
            }
            else
            {
                InventoryItem ii = null;
                bool isExit = false;

                foreach (InventoryItem item in inventoryItemList)
                {
                    if (item.GetInventroy.ID == id)
                    {
                        isExit = true;
                        ii = item;
                        break;
                    }
                }

                if (isExit)
                {
                    ii.Count++;
                }
                else
                {
                    ii = new InventoryItem();
                    ii.GetInventroy = inventory;                   
                    ii.Count = 1;
                    inventoryItemList.Add(ii);
                }
            } 
        }

        OnInventoryChanged();
    }

    private void Awake()
    {
        Instance = this;
        ReadInventoryInfo();
    }

    public void OpenBag()
    {
        knapsackGo.SetActive(true);
        if (hasReadItems == false)
        {
            hasReadItems = true;
            ReadInventoryItemInfo();
        }
    }
}
