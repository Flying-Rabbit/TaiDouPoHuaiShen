using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBar : MonoBehaviour {

    public Button bagBtn;
    public Button shopBtn;
    public Button skillBtn;
    public Button battleBtn;
    public Button systemBtn;
    public Button questBtn;

    private void Awake()
    {
        bagBtn.onClick.AddListener(() => KnapsackManager.Instance.OpenBag());
        questBtn.onClick.AddListener(() => TaskManager.Instance.ShowTaskPanel());
        skillBtn.onClick.AddListener(() => SkillManager.Instance.ShowSkillPanel());
    }
}
