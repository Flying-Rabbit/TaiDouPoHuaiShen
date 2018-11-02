using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour {

    public Image taskTypeImg;
    public Image taskIcon;
    public Text taskName;
    public Text taskDes;
    public Text taskRewardGold;
    public Text taskRewardDiamond;
    public Button battleBtn;
    public Text battleBtnText;
    public Button rewardBtn;
    public Text rewardBtnText;

    private Task task;

    private void Start()
    {
        battleBtn.onClick.AddListener(OnBattleBtnClick);
        rewardBtn.onClick.AddListener(OnRewardBtnClick);
    }

    public void SetTaskUI(Task task)
    {
        if (task != null)
        {
            task.TaskStateChanged = null;
        }
        this.task = task;
        task.TaskStateChanged += TaskStateChanged;

        //tasktype
        switch (task.TaskType)
        {
            case ETaskType.Main:
                taskTypeImg.overrideSprite = Resources.Load<Sprite>("Task/pic_main");
                break;
            case ETaskType.Reward:
                taskTypeImg.overrideSprite = Resources.Load<Sprite>("Task/pic_reward");
                break;
            case ETaskType.Daily:
                taskTypeImg.overrideSprite = Resources.Load<Sprite>("Task/pic_daily");
                break;
            default:
                break;
        }

        taskIcon.overrideSprite = Resources.Load<Sprite>(task.Icon);
        taskName.text = task.Name;
        taskDes.text = task.Des;
        taskRewardGold.text = "x " + task.Gold;
        taskRewardDiamond.text = "x " + task.Diamond;

        //taskprograss
        UpdateTaskState(task);
    }


    private void UpdateTaskState(Task task)
    {
        switch (task.TaskProgress)
        {
            case ETaskProgress.NotStart:
                rewardBtn.gameObject.SetActive(false);
                battleBtn.gameObject.SetActive(true);
                battleBtnText.text = "下一步";
                break;
            case ETaskProgress.Accepted:
                rewardBtn.gameObject.SetActive(false);
                battleBtn.gameObject.SetActive(true);
                battleBtnText.text = "战斗";
                break;
            case ETaskProgress.Completed:
                rewardBtn.gameObject.SetActive(true);
                battleBtn.gameObject.SetActive(false);
                rewardBtnText.text = "领取奖励";
                break;
            case ETaskProgress.Rewarded:
                rewardBtn.gameObject.SetActive(false);
                battleBtn.gameObject.SetActive(false);
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    private void TaskStateChanged()
    {
        UpdateTaskState(task);
    }

    private void OnBattleBtnClick()
    {
        TaskManager.Instance.ExcuteTask(task);
        GetComponentInParent<TaskPanel>().Close();
    }

    private void OnRewardBtnClick()
    {

    }
}
