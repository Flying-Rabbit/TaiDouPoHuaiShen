using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{

    private Inventory mInventory;
    private int mLevel;
    private int mCount;
    private bool isDressed = false;

    public Inventory GetInventroy
    {
        get
        {
            return mInventory;
        }
        set
        {
            mInventory = value;
        }
    }

    public int Level
    {
        get
        {
            return mLevel;
        }
        set
        {
            mLevel = value;
        }
    }

    public int Count
    {
        get
        {
            return mCount;
        }
        set
        {
            mCount = value;
        }
    }

    public bool IsDressed
    {
        get
        {
            return isDressed;
        }
        set
        {
            isDressed = value;
        }
    }
}
