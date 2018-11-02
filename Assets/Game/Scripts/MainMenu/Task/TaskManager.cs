using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

    public TextAsset taskAsset;
    public static TaskManager Instance;
    private ArrayList taskArrayList = new ArrayList();
    public GameObject taskPanel;
    public GameObject dialogPanel;
    private PlayerAutoMove playerAuto;
    private PlayerAutoMove PlayerAuto
    {
        get
        {
            if (playerAuto == null)
            {
                playerAuto = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutoMove>();

            }
            return playerAuto;
        }
    }
    public ArrayList TaskArrayList
    {
        get
        {
            return taskArrayList;
        }
    }
    private Task currentTask;

    private void Awake()
    {
        Instance = this;
        InitTask();
    }

    public void InitTask()
    {
        string[] taskInfoArray = taskAsset.ToString().Split('\n');
        foreach (string taskInfo in taskInfoArray)
        {
            string[] taskStr = taskInfo.Split('|');
            Task task = new Task();
            task.Id = int.Parse(taskStr[0]);
            switch (taskStr[1])
            {
                case "Main":
                    task.TaskType = ETaskType.Main;
                    break;

                case "Daily":
                    task.TaskType = ETaskType.Daily;
                    break;

                case "Reward":
                    task.TaskType = ETaskType.Reward;
                    break;

              default:
                    break;
            }
            task.Name = taskStr[2];
            task.Icon = taskStr[3];
            task.Des = taskStr[4];
            task.Gold = int.Parse(taskStr[5]);
            task.Diamond = int.Parse(taskStr[6]);
            task.TalkNPC = taskStr[7];
            task.IdNPC = int.Parse(taskStr[8]);
            task.IdDungeon = int.Parse(taskStr[9]);
            task.TaskProgress = ETaskProgress.NotStart;
            taskArrayList.Add(task);
        }
    }

    public void ShowTaskPanel()
    {
        taskPanel.SetActive(true);
    }

    public void ExcuteTask(Task task)
    {
        this.currentTask = task;

        if (task.TaskProgress == ETaskProgress.NotStart)
        {
            //move to the NPC position
            PlayerAuto.AutoMove(NPCManager.Instance.GetNPCByID(task.Id).transform.position);
        }
        else
        {
            EnterDungeon();
        }
    }

    public void AcceptTask()
    {
        if (currentTask.TaskProgress == ETaskProgress.NotStart)
        {
            currentTask.TaskProgress = ETaskProgress.Accepted;
            EnterDungeon();
        }
    }

    public void OnArrived()
    {   
        if (currentTask.TaskProgress == ETaskProgress.NotStart)
        {
            print("show dialog");
            dialogPanel.SetActive(true);
            NPCDialog.Instance.UpdateDialog(currentTask.Des);
        }
        else if(currentTask.TaskProgress == ETaskProgress.Accepted)
        {
            print("***enter dungeon****");
        }       
    }

    private void EnterDungeon()
    {
        PlayerAuto.AutoMove(NPCManager.Instance.GetDungeonEntry().transform.position);
    }
}
