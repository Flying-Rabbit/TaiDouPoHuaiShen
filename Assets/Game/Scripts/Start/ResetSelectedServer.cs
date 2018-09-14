using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetSelectedServer : MonoBehaviour {

    private GameObject server;
    private ServerProperty sp;

	void Start () {

        GetComponent<Button>().onClick.AddListener(UpdateInfo);
        sp = GetComponent<ServerProperty>();
	}

    private void UpdateInfo()
    {
        server = GameObject.FindGameObjectWithTag("server");

        if (server == null)
        {
            Debug.Log("did not find GameObject: Server");
            return;
        }
        
        server.GetComponent<InitServerList>().InitSelected(sp.ip, sp.serverName, sp.count);       
    }    
}
