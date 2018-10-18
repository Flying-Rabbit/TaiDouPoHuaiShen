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
    Equipt,
    EquiptLevel,
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


        //mHelmet = new InventoryItem();
        //mHelmet.GetInventroy = KnapsackManager.inventoryDict[1005];

        mCloth = new InventoryItem();
        mCloth.GetInventroy = KnapsackManager.inventoryDict[1004];

        mWeapon = new InventoryItem();
        mWeapon.GetInventroy = KnapsackManager.inventoryDict[1006];

        mShoes = new InventoryItem();
        mShoes.GetInventroy = KnapsackManager.inventoryDict[1008];

        mNecklace = new InventoryItem();
        mNecklace.GetInventroy = KnapsackManager.inventoryDict[1007];

        //mBracelet = new InventoryItem();
        //mBracelet.GetInventroy = KnapsackManager.inventoryDict[1001];

        //mRing = new InventoryItem();
        //mRing.GetInventroy = KnapsackManager.inventoryDict[1003];

        //mWing = new InventoryItem();
        //mWing.GetInventroy = KnapsackManager.inventoryDict[1002];


        OnPlayerInfoChanged(PlayerInfoType.All);
    }

    private void InitHPDamagePower()
    {
        mHP = mLevel * 100;
        mAttack = mLevel * 50;
        mPower = mHP + mAttack;

        PutOnEquip(mHelmet, -1);
        PutOnEquip(mCloth, -1);
        PutOnEquip(mWeapon, -1);
        PutOnEquip(mShoes, -1);
        PutOnEquip(mNecklace, -1);
        PutOnEquip(mBracelet, -1);
        PutOnEquip(mRing, -1);
        PutOnEquip(mWing, -1);
    }

    public void ChangeName(string newName)
    {
        mName = newName;
        OnPlayerInfoChanged(PlayerInfoType.Name);
    }

    public void PutOnEquip(InventoryItem item, int itemId)
    {       
        if (item == null)
        {
            return;
        }

        item.IsDressed = true;
        InventoryUI.Instance.ClearPrice();

        if (itemId >= 0)
        {
            bool isSwitchEquipt = false;

            switch (item.GetInventroy.EquipTYPE)
            {
                case EquipType.Helmet:
                    if (Helmet != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Helmet;
                        Helmet = item;
                        item = temp;                       
                    }
                    else
                    {
                        Helmet = item;                        
                    }
                    break;
                case EquipType.Cloth:
                    if (Cloth != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Cloth;
                        Cloth = item;
                        item = temp;                       
                    }
                    else
                    {
                        Cloth = item;                        
                    }
                    break;
                case EquipType.Weapon:
                    if (Weapon != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Weapon;
                        Weapon = item;
                        item = temp;                       
                    }
                    else
                    {
                        Weapon = item;                        
                    }
                    break;
                case EquipType.Shoes:
                    if (Shoes != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Shoes;
                        Shoes = item;
                        item = temp;                       
                    }
                    else
                    {
                        Shoes = item;                       
                    }
                    break;
                case EquipType.Necklace:
                    if (Necklace != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Necklace;
                        Necklace = item;
                        item = temp;                       
                    }
                    else
                    {
                        Necklace = item;                      
                    }
                    break;
                case EquipType.Bracelet:
                    if (Bracelet != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Bracelet;
                        Bracelet = item;
                        item = temp;                       
                    }
                    else
                    {
                        Bracelet = item;                        
                    }
                    break;
                case EquipType.Ring:
                    if (Ring != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Ring;
                        Ring = item;
                        item = temp;                       
                    }
                    else
                    {
                        Ring = item;                        
                    }
                    break;
                case EquipType.Wing:
                    if (Wing != null)
                    {
                        isSwitchEquipt = true;
                        InventoryItem temp = Wing;
                        Wing = item;
                        item = temp;                        
                    }
                    else
                    {
                        Wing = item;                       
                    }
                    break;
                default:
                    break;
            }

            if (isSwitchEquipt)
            {
                InventoryUI.Instance.itUIList[itemId].SetInventoryItem(item);               
                item.IsDressed = false;
                item.Count = 1;
            }
            else
            {
                InventoryUI.Instance.itUIList[itemId].Clear();
                InventoryUI.Instance.itUIList[itemId].Clear();
                KnapsackManager.inventoryItemList.Remove(item);
                InventoryUI.Instance.UpdateCount();
                          
            }

            //print(InventoryManager.Instance.inventoryItemList.Count);
        }   

        Inventory inventory = item.GetInventroy;
        
        mHP += inventory.HP;
        mAttack += inventory.Attack;
        mPower += inventory.Power;

        OnPlayerInfoChanged(PlayerInfoType.All);
    }

    public void PutOffEquip(InventoryItem item)
    {
        if (item == null)
        {
            return;
        }
        item.IsDressed = false;
        item.Count = 1;
        KnapsackManager.inventoryItemList.Add(item);
        InventoryUI.Instance.UpdateCount();

        switch (item.GetInventroy.EquipTYPE)
        {
            case EquipType.Helmet:
                Helmet = null;
                KnapsackRole.Instance.helmet.Clear();
                break;
            case EquipType.Cloth:
                Cloth = null;
                KnapsackRole.Instance.cloth.Clear();
                break;
            case EquipType.Weapon:
                Weapon = null;
                KnapsackRole.Instance.weapon.Clear();
                break;
            case EquipType.Shoes:
                Shoes = null;
                KnapsackRole.Instance.shoes.Clear();
                break;
            case EquipType.Necklace:
                Necklace = null;
                KnapsackRole.Instance.necklace.Clear();
                break;
            case EquipType.Bracelet:
                Bracelet = null;
                KnapsackRole.Instance.bracelet.Clear();
                break;
            case EquipType.Ring:
                Ring = null;
                KnapsackRole.Instance.ring.Clear();
                break;
            case EquipType.Wing:
                Wing = null;
                KnapsackRole.Instance.wing.Clear();
                break;
            default:
                break;
        }

        bool findSlot = false;
        int count = KnapsackManager.inventoryItemList.Count;

        for (int i = 0; i < count; i++)
        {
            if (InventoryUI.Instance.itUIList[i].isEmpty)
            {
                InventoryUI.Instance.itUIList[i].SetInventoryItem(item);
                findSlot = true;
                break;
            }
        }

        if (findSlot == false)
        {
            InventoryUI.Instance.itUIList[count].SetInventoryItem(item);
        }

        Inventory inventory = item.GetInventroy;
      
        this.mHP -= inventory.HP;
        this.mAttack -= inventory.Attack;
        this.mPower -= inventory.Power;
        OnPlayerInfoChanged(PlayerInfoType.All);
    }

    public bool UpgradeEquipt(InventoryItem item)
    {
        int needGolds = (item.Level + 1) * item.GetInventroy.Price;

        if (Gold < needGolds)
            return false;
        else
        {
            Gold -= needGolds;
            item.Level += 1;
            item.GetInventroy.HP += 100 * item.Level;
            item.GetInventroy.Attack += 10 * item.Level;
            OnPlayerInfoChanged(PlayerInfoType.All);
            return true;
        }
    }

    public void ChangeGold(int value)
    {
        Gold += value;
        OnPlayerInfoChanged(PlayerInfoType.Gold);
    }

    public void ChangeEnergy(int value)
    {
        Energy += value;
        Energy = Energy > 100 ? 100 : Energy;
        OnPlayerInfoChanged(PlayerInfoType.Energy);
    }


}
