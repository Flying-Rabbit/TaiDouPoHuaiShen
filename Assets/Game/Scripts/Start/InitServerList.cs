using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct ServerInfo
{
    public string ip;
    public string serverName;
    public int count;
}

public class InitServerList : MonoBehaviour
{

    public Transform contentTransform;
    public Transform selectedServerTransfrom;
    public GameObject redServerPrefab;
    public GameObject greenServerPrefab;

    private bool hasInit = false;
    public List<ServerInfo> serverInfoList;
    private GameObject selectedServer;



    private void Start()
    {
        //TODO  get server info 
        serverInfoList = new List<ServerInfo>();

        //Simulation-----
        for (int i = 0; i < 20; i++)
        {
            ServerInfo serverInfo;
            serverInfo.ip = "127.0.0.1:9080";
            serverInfo.serverName = (i + 1) + "区  火德星君";
            serverInfo.count = Random.Range(0, 100);
            serverInfoList.Add(serverInfo);          
        }


        if (hasInit == false && serverInfoList != null)
        {
            InitSelected(serverInfoList[0].ip, serverInfoList[0].serverName, serverInfoList[0].count);
            InitList();
            hasInit = true;
        }

    }

    private void InitList()
    {
        int serverNum = serverInfoList.Count;

        for (int i = 0; i < serverNum; i++)
        {
            int count = serverInfoList[i].count;

            GameObject go;

            if (count > 50)
            {
                go = Instantiate(redServerPrefab);
            }
            else
            {
                go = Instantiate(greenServerPrefab);
            }

            go.transform.SetParent(contentTransform,false);
            ServerProperty sp = go.GetComponent<ServerProperty>();
            sp.ip = serverInfoList[i].ip;
            sp.serverName = serverInfoList[i].serverName;
            sp.count = serverInfoList[i].count;

            go.GetComponentInChildren<Text>().text = sp.serverName;
        }

        int lines = serverNum % 2==0? serverNum / 2: serverNum / 2 +1;
   
        contentTransform.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -1 * lines * 47, 0);
        
    }

    public void InitSelected(string ip, string serverName, int count)
    {
        if (count > 50)
        {
            selectedServer = selectedServerTransfrom.GetChild(0).gameObject;
            selectedServer.SetActive(true);
            selectedServerTransfrom.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            selectedServer = selectedServerTransfrom.GetChild(1).gameObject;
            selectedServer.SetActive(true);
            selectedServerTransfrom.GetChild(0).gameObject.SetActive(false);
        }

        ServerProperty sp = selectedServer.GetComponent<ServerProperty>();
        sp.ip = ip;
        sp.serverName = serverName;
        sp.count = count;
        selectedServer.GetComponentInChildren<Text>().text = sp.serverName;

    }
}
