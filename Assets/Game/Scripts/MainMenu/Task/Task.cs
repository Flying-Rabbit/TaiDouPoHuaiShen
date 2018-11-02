using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETaskType
{
    Main,       //主线任务
    Reward,     //奖金任务
    Daily       //日常任务
}

public enum ETaskProgress
{
    NotStart,
    Accepted,
    Completed,
    Rewarded
}

public class Task
{

    //a)Id
    //b)任务类型（Main,Reward，Daily）
    //c)名称
    //d)图标
    //e)任务描述
    //f)获得的金币奖励
    //g)获得的钻石奖励
    //h)跟npc交谈的话语
    //i)Npc的id
    //j)副本id
    //k)任务的状态
    //    i.未开始
    //    ii.接受任务
    //    iii.任务完成
    //    iv.获取奖励（结束）

    #region 字段
    private int id;
    private ETaskType taskType;
    private string name;
    private string icon;
    private string des;
    private int gold;
    private int diamond;
    private string talkNPC;
    private int idNPC;
    private int idDungeon;
    private ETaskProgress taskProgress;
    #endregion

    #region 属性
    public int Id
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

    public ETaskType TaskType
    {
        get
        {
            return taskType;
        }

        set
        {
            taskType = value;
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

    public string Des
    {
        get
        {
            return des;
        }

        set
        {
            des = value;
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }

        set
        {
            gold = value;
        }
    }

    public int Diamond
    {
        get
        {
            return diamond;
        }

        set
        {
            diamond = value;
        }
    }

    public string TalkNPC
    {
        get
        {
            return talkNPC;
        }

        set
        {
            talkNPC = value;
        }
    }

    public int IdNPC
    {
        get
        {
            return idNPC;
        }

        set
        {
            idNPC = value;
        }
    }

    public int IdDungeon
    {
        get
        {
            return idDungeon;
        }

        set
        {
            idDungeon = value;
        }
    }

    public ETaskProgress TaskProgress
    {
        get
        {
            return taskProgress;
        }

        set
        {
            if (taskProgress != value)
            {
                taskProgress = value;
                if(TaskStateChanged!=null)
                    TaskStateChanged.Invoke();
            }
        }
    }
    #endregion

    public Action TaskStateChanged;

}
