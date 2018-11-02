using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public Image iconOne;
    public Text levelOne;
    public Image iconTwo;
    public Text levelTwo;
    public Image iconThree;
    public Text levelThree;
    public Text skillInfo;
    public Toggle skillOneBtn;
    public Toggle skillTwoBtn;
    public Toggle skillThreeBtn;
    public Button promptBtn;
    public Button closeBtn;

    private Skill selectedSkill;
    private Skill one;
    private Skill two;
    private Skill three;

    private void Awake()
    {
        one = SkillManager.Instance.GetSkillByPos(EPosType.One);
        two = SkillManager.Instance.GetSkillByPos(EPosType.Two);
        three = SkillManager.Instance.GetSkillByPos(EPosType.Three);
        selectedSkill = one;
        skillOneBtn.onValueChanged.AddListener(state =>
        {
            if (state)
            {
                selectedSkill = one;
                UpdateUI();
            }
        });
        skillTwoBtn.onValueChanged.AddListener(state =>
        {
            if (state)
            {
                selectedSkill = two;
                UpdateUI();
            }
        });
        skillThreeBtn.onValueChanged.AddListener(state =>
        {
            if (state)
            {
                selectedSkill = three;
                UpdateUI();
            }
        });
        closeBtn.onClick.AddListener(() =>gameObject.SetActive(false));
        promptBtn.onClick.AddListener(OnClickPromptBtn);
    }

    private void Start()
    {
        InitUI();
        UpdateUI();
    }

    private void InitUI()
    {
        iconOne.overrideSprite = Resources.Load<Sprite>(one.Icon);
        iconTwo.overrideSprite = Resources.Load<Sprite>(two.Icon);
        iconThree.overrideSprite = Resources.Load<Sprite>(three.Icon);       
    }

    private void UpdateUI()
    {
        levelOne.text = "Lv " + one.SkillLevel;
        levelTwo.text = "Lv " + two.SkillLevel;
        levelThree.text = "Lv " + three.SkillLevel;
        skillInfo.text = "当前技能的攻击力为：" + (selectedSkill.Damage * selectedSkill.SkillLevel) + '\n'
                       + "下一级攻击力为： " + (selectedSkill.Damage * (selectedSkill.SkillLevel + 1)) + '\n'
                       + "升级所需金币为：" + selectedSkill.SkillLevel * 500;
        if (PlayerInfo.Instance.Gold < selectedSkill.SkillLevel * 500)
        {
            promptBtn.interactable = false;
        }
        else
        {
            promptBtn.interactable = true;
        }
    }

    private void OnClickPromptBtn()
    {
        if (selectedSkill.SkillLevel * 500 > PlayerInfo.Instance.Gold)
        {
            return;
        }
               
        PlayerInfo.Instance.ChangeGold(-500 * selectedSkill.SkillLevel);
        selectedSkill.SkillLevel += 1;
        UpdateUI();
    }
}
