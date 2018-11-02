using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed = 5f;
    private Animator anim;
    private Rigidbody rigid;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = -Input.GetAxis("Horizontal");
        float v = -Input.GetAxis("Vertical");
        if (Mathf.Abs(h) + Mathf.Abs(v) > 0f)
        {
            rigid.velocity = new Vector3(h * speed, rigid.velocity.y, v * speed);
            anim.SetBool("Move", true);
            transform.LookAt(transform.position + new Vector3(h, 0, v));
        }
        else
        {
            anim.SetBool("Move", false);
        }
    }
}
