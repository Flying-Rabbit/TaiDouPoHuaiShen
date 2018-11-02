using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    public static NPCManager Instance;

    public GameObject[] npc;
    public GameObject dungeonEntery;
    private Dictionary<int, GameObject> npcDict = new Dictionary<int, GameObject>();

    private void Awake()
    {
        Instance = this;
        Init();
    }
    private void Init()
    {
        foreach (GameObject go in npc)
        {
            int id = int.Parse(go.name.Substring(0, 4));           
            npcDict.Add(id, go);
        }
    }

    public GameObject GetNPCByID(int id)
    {
        GameObject go = null;
        npcDict.TryGetValue(id, out go);        
        return go;
    }

    public GameObject GetDungeonEntry()
    {
        return dungeonEntery;
    }
}
