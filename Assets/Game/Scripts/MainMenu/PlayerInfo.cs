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
    #endregion

    private float energyTimer = 0f;
    private float toughenTimer = 0f;
    public event Action<PlayerInfoType> OnPlayerInfoChanged;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {       
        Init();
        OnPlayerInfoChanged(PlayerInfoType.All);
    }
    private void Update()
    {
        if (mEnergy < 100)
        {
            energyTimer += Time.deltaTime;
            if (energyTimer >= 60f)
            {
                mEnergy += 1;
                OnPlayerInfoChanged(PlayerInfoType.Energy);
                energyTimer -= 60f;
            }
        }
        else
        {
            energyTimer = 0f;
        }

        if (mToughen < 50)
        {
            toughenTimer += Time.deltaTime;
            if (toughenTimer >= 60f)
            {
                mToughen += 1;
                OnPlayerInfoChanged(PlayerInfoType.Toughen);
                toughenTimer -= 60f;
            }
        }
        else
        {
            toughenTimer = 0f;
        }
    }

    private void Init()
    {
        this.mName = "骑猪的圣骑士";
        this.mHeadPortraitID = 0;
        this.mLevel = 12;
        this.mPower = 1050;
        this.mExp = 123;
        this.mDiamond = 10000;
        this.mGold = 10000;
        this.mEnergy = 78;
        this.mToughen = 29;        
    }
}
