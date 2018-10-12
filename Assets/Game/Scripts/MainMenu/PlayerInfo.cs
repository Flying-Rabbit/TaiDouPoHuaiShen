using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerInfoType
{
    Name,
    HeadPortrait,
    Level,
    Power,
    Exp,
    Diamond,
    Gold,
    Energy,
    Toughen,
    HP,
    Attack,
    All
}

public class PlayerInfo : MonoBehaviour {

    //姓名
    //头像
    //等级
    //战斗力
    //经验数
    //钻石数
    //金币数
    //体力数
    //历练数

    public static PlayerInfo Instance;

    #region field
    private string mName;
    private int mHeadPortraitID;
    private int mLevel;
    private int mPower;
    private int mExp;
    private int mDiamond;
    private int mGold;
    private int mEnergy;
    private int mToughen;
    private int mAttack;
    private int mHP;
    private InventoryItem mHelmet;
    private InventoryItem mCloth;
    private InventoryItem mWeapon;
    private InventoryItem mShoes;
    private InventoryItem mNecklace;
    private InventoryItem mBracelet;
    private InventoryItem mRing;
    private InventoryItem mWing;
    #endregion

    #region Property
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
    public int HeadPortraitID
    {
        get
        {
            return mHeadPortraitID;
        }
        set
        {
            mHeadPortraitID = value;
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
    public int Exp
    {
        get
        {
            return mExp;
        }
        set
        {
            mExp = value;
        }
    }
    public int Diamond
    {
        get
        {
            return mDiamond;
        }
        set
        {
            mDiamond = value;
        }
    }
    public int Gold
    {
        get
        {
            return mGold;
        }
        set
        {
            mGold = value;
        }
    }
    public int Energy
    {
        get
        {
            return mEnergy;
        }
        set
        {
            mEnergy = value;
        }
    }
    public int Toughen
    {
        get
        {
            return mToughen;
        }
        set
        {
            mToughen = value;
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
    public InventoryItem Helmet
    {
        get
        {
            return mHelmet;
        }
        set
        {
            mHelmet = value;
        }
    }
    public InventoryItem Cloth
    {
        get
        {
            return mCloth;
        }
        set
        {
            mCloth = value;
        }
    }
    public InventoryItem Weapon
    {
        get
        {
            return mWeapon;
        }
        set
        {
            mWeapon = value;
        }
    }
    public InventoryItem Shoes
    {
        get
        {
            return mShoes;
        }
        set
        {
            mShoes = value;
        }
    }
    public InventoryItem Necklace
    {
        get
        {
            return mNecklace;
        }
        set
        {
            mNecklace = value;
        }
    }
    public InventoryItem Bracelet
    {
        get
        {
            return mBracelet;
        }
        set
        {
            mBracelet = value;
        }
    }
    public InventoryItem Ring
    {
        get
        {
            return mRing;
        }
        set
        {
            mRing = value;
        }
    }
    public InventoryItem Wing
    {
        get
        {
            return mWing;
        }
        set
        {
            mWing = value;
        }
    }
    #endregion


    public event Action<PlayerInfoType> OnPlayerInfoChanged;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {       
        Init();       
    }   


    private void Init()
    {
        mName = "骑猪的圣骑士";
        mHeadPortraitID = 0;
        mLevel = 12;
        mPower = 1050;
        mExp = 123;
        mDiamond = 10000;
        mGold = 10000;
        mEnergy = 78;
        mToughen = 29;

        //mHelmet = 1005;
        //mCloth = 1004;
        //mWeapon = 1006;
        //mShoes = 1008;
        //mNecklace = 1007;
        //mBracelet = 1001;
        //mRing = 1003;
        //mWing = 1002;
        mHelmet = new InventoryItem();
        mHelmet.GetInventroy = InventoryManager.Instance.inventoryDict[1005];

        mCloth = new InventoryItem();
        mCloth.GetInventroy = InventoryManager.Instance.inventoryDict[1004];

        mWeapon = new InventoryItem();
        mWeapon.GetInventroy = InventoryManager.Instance.inventoryDict[1006];

        mShoes = new InventoryItem();
        mShoes.GetInventroy = InventoryManager.Instance.inventoryDict[1008];

        mNecklace = new InventoryItem();
        mNecklace.GetInventroy = InventoryManager.Instance.inventoryDict[1007];

        mBracelet = new InventoryItem();
        mBracelet.GetInventroy = InventoryManager.Instance.inventoryDict[1001];

        mRing = new InventoryItem();
        mRing.GetInventroy = InventoryManager.Instance.inventoryDict[1003];

        mWing = new InventoryItem();
        mWing.GetInventroy = InventoryManager.Instance.inventoryDict[1002];


        OnPlayerInfoChanged(PlayerInfoType.All);
    }

    public void ChangeName(string newName)
    {
        mName = newName;
        OnPlayerInfoChanged(PlayerInfoType.Name);
    }

    void PutOnEquip(InventoryItem item)
    {       
        if (item == null)
        {
            return;
        }

        Inventory inventory = item.GetInventroy;
        
        mHP += inventory.HP;
        mAttack += inventory.Attack;
        mPower += inventory.Power;
    }

    void PutOffEquip(InventoryItem item)
    {
        if (item == null)
        {
            return;
        }
        Inventory inventory = item.GetInventroy;
      
        this.mHP -= inventory.HP;
        this.mAttack -= inventory.Attack;
        this.mPower -= inventory.Power;
    }

    void InitHPDamagePower()
    {
        mHP = mLevel * 100;
        mAttack = mLevel * 50;
        mPower = mHP + mAttack;

        PutOnEquip(mHelmet);
        PutOnEquip(mCloth);
        PutOnEquip(mWeapon);
        PutOnEquip(mShoes);
        PutOnEquip(mNecklace);
        PutOnEquip(mBracelet);
        PutOnEquip(mRing);
        PutOnEquip(mWing);
    }
}
