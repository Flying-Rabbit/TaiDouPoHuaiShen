using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour {
        
    public Text dialog;
    public Button acceptBtn;
    private Task currenTask;

    public static NPCDialog Instance;

    private void Awake()
    {        
        Instance = this;
        acceptBtn.onClick.AddListener(() => {
            TaskManager.Instance.AcceptTask();
            gameObject.SetActive(false);
        });
       
        print("init dialog");
    }

    public void UpdateDialog(string des)
    {   
        dialog.text = des;
    }

    
}
