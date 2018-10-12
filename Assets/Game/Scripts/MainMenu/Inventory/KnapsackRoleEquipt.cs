using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnapsackRoleEquipt : MonoBehaviour {

    private Image img;
    private Button equiptBtn;
    private InventoryItem item;

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
        GetComponentInParent<Knapsack>().OnPressed(item, false);
    }

    public void UpdateImgByInventoryItem(InventoryItem item)
    {
        this.item = item;
        Img.overrideSprite = Resources.Load<Sprite>(item.GetInventroy.Icon);
                
    }
}
