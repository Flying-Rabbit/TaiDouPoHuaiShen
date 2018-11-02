using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : MonoBehaviour {

    public Transform taskUIParent;
    public GameObject taskUIPrefab;
    public GameObject rewardPanel;
    public Button closeBtn;
    

    private void Start()
    {
        InitTaskListUI();
        closeBtn.onClick.AddListener(Close);  
    }

    private void InitTaskListUI()
    {
        ArrayList taskArrayList = TaskManager.Instance.TaskArrayList;
        foreach (Task task in taskArrayList)
        {       
            GameObject go = Instantiate(taskUIPrefab);
            go.transform.SetParent(taskUIParent);
            go.GetComponent<TaskUI>().SetTaskUI(task);
        }
    }

    public void ShowRewardPanel()
    {
        rewardPanel.SetActive(true);
    }

    public void Close()
    {
        rewardPanel.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
