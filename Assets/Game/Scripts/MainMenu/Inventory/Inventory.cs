using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    Equip,
    Drug,
    Box
}

public enum EquipType
{
    Helmet,
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing
}

public class Inventory
{
    #region Field
    private int mID;
    private string mName;
    private string icon;
    private InventoryType mInventoryType; //类型
    private EquipType mEquipType;   //装备类型
    private int mPrice = 0;
    private int mStarLevel = 1;
    private int mQuality = 1;
    private int mAttack = 0;
    private int mHP = 0;
    private int mPower = 0;
    private PlayerInfoType mInfoType;//作用类型，表示作用在哪个属性上
    private int mApplyValue;//作用值
    private string mDes;//描述
    #endregion

    #region Attribute
    public int ID
    {
        get
        {
            return mID;
        }
        set
        {
            mID = value;
        }
    }

    public string Name
    {
        get
        {
            return mName;
        }
        set
        {
            mName = value;
        }
    }

    public string Icon
    {
        get
        {
            return icon;
        }
        set
        {
            icon = value;
        }
    }

    public InventoryType InventoryTYPE
    {
        get
        {
            return mInventoryType;
        }
        set
        {
            mInventoryType = value;
        }
    }

    public EquipType EquipTYPE
    {
        get
        {
            return mEquipType;
        }
        set
        {
            mEquipType = value;
        }
    }
   
    public int Price
    {
        get
        {
            return mPrice;
        }
        set
        {
            mPrice = value;
        }
    }

    public int StarLevel
    {
        get
        {
            return mStarLevel;
        }
        set
        {
            mStarLevel = value;
        }
    }

    public int Quality
    {
        get
        {
            return mQuality;
        }
        set
        {
            mQuality = value;
        }
    }

    public int Attack
    {
        get
        {
            return mAttack;
        }
        set
        {
            mAttack = value;
        }
    }

    public int HP
    {
        get
        {
            return mHP;
        }
        set
        {
            mHP = value;
        }
    }

    public int Power
    {
        get
        {
            return mPower;
        }
        set
        {
            mPower = value;
        }
    }

    public PlayerInfoType InfoTYPE
    {
        get
        {
            return mInfoType;
        }
        set
        {
            mInfoType = value;
        }
    }

    public int ApplyValue
    {
        get
        {
            return mApplyValue;
        }
        set
        {
            mApplyValue = value;
        }
    }

    public string Des
    {
        get
        {
            return mDes;
        }
        set
        {
            mDes = value;
        }
    }
    #endregion
}
