using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESkillType
{
    Basic,
    Skill
}

public enum EPosType
{
    Basic,One,Two,Three
}

public class Skill
{
    #region Field
    private string id;
    private string name;
    private string icon;
    private EPlayerType playerType;
    private ESkillType skillType;
    private EPosType posType;
    private int coldTime;
    private int damage;
    private int skillLevel = 1;
    #endregion

    #region Attribute
    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
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

    public EPlayerType PlayerType
    {
        get
        {
            return playerType;
        }

        set
        {
            playerType = value;
        }
    }

    public ESkillType SkillType
    {
        get
        {
            return skillType;
        }

        set
        {
            skillType = value;
        }
    }

    public EPosType PosType
    {
        get
        {
            return posType;
        }

        set
        {
            posType = value;
        }
    }

    public int ColdTime
    {
        get
        {
            return coldTime;
        }

        set
        {
            coldTime = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public int SkillLevel
    {
        get
        {
            return skillLevel;
        }

        set
        {
            skillLevel = value;
        }
    }
    #endregion

}
