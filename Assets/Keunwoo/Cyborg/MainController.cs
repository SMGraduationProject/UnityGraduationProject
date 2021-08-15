using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Rigidbody rigidbody;
    private float h;
    private float v;
    private float moveX;
    private float moveZ;
    private float speedH = 50f;
    private float speedZ = 80f;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("jump_complete", -1, 0);
        }
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        animator.SetFloat("h", h);
        animator.SetFloat("v", v);

        moveX = h * speedH * Time.deltaTime;
        moveZ = v * speedZ * Time.deltaTime;

        rigidbody.velocity = new Vector3(moveX, 0, moveZ);
    }
}
