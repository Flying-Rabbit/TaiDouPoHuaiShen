using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static int GetRequiredExpByLevel(int level)
    {
        return (100 + 5 * (level - 2)) * (level - 1);
    }

    
}
