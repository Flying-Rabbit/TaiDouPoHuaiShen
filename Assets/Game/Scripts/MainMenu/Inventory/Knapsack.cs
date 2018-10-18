using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knapsack : MonoBehaviour {
         
    public EquiptInfo equiptInfo;
    public ItemInfo itemInfo;
    public Button closeBtn;
    private float xPos = 562f;
    private RectTransform rtrm;

    private void Awake()
    {
        rtrm = equiptInfo.gameObject.GetComponent<RectTransform>();
        equiptInfo.gameObject.SetActive(false);
        itemInfo.gameObject.SetActive(false);
        closeBtn.onClick.AddListener(() =>
        {
            equiptInfo.gameObject.SetActive(false);
            itemInfo.gameObject.SetActive(false);
            gameObject.SetActive(false);
        });

    }
    public void OnPressed(InventoryItem item, bool isRight, int itemId)
    {
        //Debug.Log(item.GetInventroy.ID + "******" + item.GetInventroy.Name);
        switch (item.GetInventroy.InventoryTYPE)
        {
            case InventoryType.Equip:
                ShowEquiptInfo(item, isRight, itemId);
                break;
            case InventoryType.Drug:               
            case InventoryType.Box:
                ShowItemInfo(item, isRight, itemId);
                break;
            default:
                break;
        }
        
    }

    private void ShowEquiptInfo(InventoryItem item, bool isRight, int itemId)
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

        equiptInfo.UpdateShow(item, isRight, itemId);
    }

    private void ShowItemInfo(InventoryItem item, bool isRight, int itemId)
    {
        equiptInfo.gameObject.SetActive(false);
        itemInfo.gameObject.SetActive(true);
        itemInfo.UpdateShow(item, itemId);
    }
}
