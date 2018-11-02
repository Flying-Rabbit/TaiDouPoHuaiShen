using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAutoMove : MonoBehaviour {

    private NavMeshAgent nav;
    public float minDistance = 3f;
    private Animator anim;    

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;
        anim = GetComponent<Animator>();
    }

    public void AutoMove(Vector3 targetPos)
    {
        GetComponent<PlayerMove>().enabled = false;
        nav.enabled = true;
        nav.SetDestination(targetPos);
        anim.SetBool("Move", true);       
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;
            transform.LookAt(transform.position + nav.velocity);
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (Mathf.Abs(h) + Mathf.Abs(v) > 0f)
            {
                StopAutoMove();
                break;
            }
                if (nav.remainingDistance <= minDistance)
            {
                anim.SetBool("Move", false);
                nav.isStopped = true;
                nav.enabled = false;                         
                TaskManager.Instance.OnArrived();
                GetComponent<PlayerMove>().enabled = true;
                break;
            }
        }
    }

    private void StopAutoMove()
    {
        if (nav.enabled)
        {
            nav.isStopped = true;
            nav.enabled = false;
            GetComponent<PlayerMove>().enabled = true;
        }
    }
}
