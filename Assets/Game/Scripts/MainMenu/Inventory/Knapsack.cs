using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour {
         
    public EquiptInfo equiptInfo;
    public ItemInfo itemInfo;
    private float xPos = 562f;
    private RectTransform rtrm;

    private void Awake()
    {
        rtrm = equiptInfo.gameObject.GetComponent<RectTransform>();
        equiptInfo.gameObject.SetActive(false);
        itemInfo.gameObject.SetActive(false);
    }
    public void OnPressed(InventoryItem item, bool isRight)
    {
        //Debug.Log(item.GetInventroy.ID + "******" + item.GetInventroy.Name);
        switch (item.GetInventroy.InventoryTYPE)
        {
            case InventoryType.Equip:
                ShowEquiptInfo(item, isRight);
                break;
            case InventoryType.Drug:               
            case InventoryType.Box:
                ShowItemInfo(item, isRight);
                break;
            default:
                break;
        }
        
    }

    private void ShowEquiptInfo(InventoryItem item, bool isRight)
    {
        equiptInfo.gameObject.SetActive(true);
        itemInfo.gameObject.SetActive(false);

        if (isRight)
        {
            rtrm.anchoredPosition = Vector3.zero;
        }
        else
        {
            rtrm.anchoredPosition = new Vector3(xPos, 0, 0);
        }

        equiptInfo.UpdateShow(item);
    }

    private void ShowItemInfo(InventoryItem item, bool isRight)
    {
        equiptInfo.gameObject.SetActive(false);
        itemInfo.gameObject.SetActive(true);
        itemInfo.UpdateShow(item);
    }
}
