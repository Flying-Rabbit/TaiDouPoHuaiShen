using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour {

    public static SkillManager Instance;
    public TextAsset skillInfoText;
    public GameObject skillPanel;
    private ArrayList skillList = new ArrayList();

    private void ReadSkillInfo()
    {
        string[] skillInfoList = skillInfoText.ToString().Split('\n');
        foreach (string skillInfo in skillInfoList)
        {
            string[] skill = skillInfo.Split(',');
            Skill sk = new Skill();
            sk.Id = skill[0];
            sk.Name = skill[1];
            sk.Icon = skill[2];
            sk.PlayerType = skill[3] == "Warrior" ? EPlayerType.Warrior : EPlayerType.FemaleAssassin;
            sk.SkillType = skill[4] == "Basic" ? ESkillType.Basic : ESkillType.Skill;
            sk.PosType = GetPosTypeByStr(skill[5]);
            sk.ColdTime = int.Parse(skill[6]);
            sk.Damage = int.Parse(skill[7]);
            sk.SkillLevel = 1;
            skillList.Add(sk);
        }
    }

    private EPosType GetPosTypeByStr(string str)
    {
        if (str == "Basic")
        {
            return EPosType.Basic;
        }
        else if (str == "One")
        {
            return EPosType.One;
        }
        else if (str == "Two")
        {
            return EPosType.Two;
        }
        else
        {
            return EPosType.Three;
        }
    }

    private void Awake()
    {
        Instance = this;
        ReadSkillInfo();
    }

    public Skill GetSkillByPos(EPosType pos)
    {
        Skill sk = null;

        foreach (Skill skill in skillList)
        {
            if (skill.PosType == pos && skill.PlayerType == PlayerInfo.Instance.PlayerType)
            {
                sk = skill;
                break;
            }
        }

        return sk;
    }

    public void ShowSkillPanel()
    {
        skillPanel.SetActive(true);
    }
}
