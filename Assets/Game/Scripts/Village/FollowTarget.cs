using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    private GameObject target;
    public Vector3 posOffset;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");       
    }

    private void Update()
    {
        transform.position = target.transform.position + posOffset;
    }
}
