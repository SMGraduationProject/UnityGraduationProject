using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_puzzle : CodeLock
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject button;
    public GameObject item;

    int[] answer = new int[3];
    int[] insert = new int[3];

    int num = 0;

    int c1 = 0;
    int c2 = 0;
    int c3 = 0;
    int c4 = 0;
    int c5 = 0;
    int c6 = 0;
    int c7 = 0;
    int c8 = 0;
    int c9 = 0;

    int wrong = 0;

    int opened = 0;

    public static int castle_key = 0;

    public GameObject target;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }

    // Start is called before the first frame update
    void Start()
    {
        answer[0] = 1;
        answer[1] = 5;
        answer[2] = 9;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (num < 3)
            {
                target = GetClickedObject();
                if (target.Equals(one) && c1 == 0)
                {
                    if (num == 0)
                    {
                        one.GetComponent<Renderer>().material.color = Color.yellow;
                        c1 = 1;
                        insert[num] = 1;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        one.GetComponent<Renderer>().material.color = Color.red;
                        c1 = 1;
                        insert[num] = 1;
                        num += 1;
                    }
                    else
                    {
                        one.GetComponent<Renderer>().material.color = Color.blue;
                        c1 = 1;
                        insert[num] = 1;
                        num += 1;
                    }
                }
                if (target.Equals(two) && c2 == 0)
                {
                    if (num == 0)
                    {
                        two.GetComponent<Renderer>().material.color = Color.yellow;
                        c2 = 1;
                        insert[num] = 2;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        two.GetComponent<Renderer>().material.color = Color.red;
                        c2 = 1;
                        insert[num] = 2;
                        num += 1;
                    }
                    else
                    {
                        two.GetComponent<Renderer>().material.color = Color.blue;
                        c2 = 1;
                        insert[num] = 2;
                        num += 1;
                    }
                }
                if (target.Equals(three) && c3 == 0)
                {
                    if (num == 0)
                    {
                        three.GetComponent<Renderer>().material.color = Color.yellow;
                        c3 = 1;
                        insert[num] = 3;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        three.GetComponent<Renderer>().material.color = Color.red;
                        c3 = 1;
                        insert[num] = 3;
                        num += 1;
                    }
                    else
                    {
                        three.GetComponent<Renderer>().material.color = Color.blue;
                        c3 = 1;
                        insert[num] = 3;
                        num += 1;
                    }
                }
                if (target.Equals(four) && c4 == 0)
                {
                    if (num == 0)
                    {
                        four.GetComponent<Renderer>().material.color = Color.yellow;
                        c4 = 1;
                        insert[num] = 4;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        four.GetComponent<Renderer>().material.color = Color.red;
                        c4 = 1;
                        insert[num] = 4;
                        num += 1;
                    }
                    else
                    {
                        four.GetComponent<Renderer>().material.color = Color.blue;
                        c4 = 1;
                        insert[num] = 4;
                        num += 1;
                    }
                }
                if (target.Equals(five) && c5 == 0)
                {
                    if (num == 0)
                    {
                        five.GetComponent<Renderer>().material.color = Color.yellow;
                        c5 = 1;
                        insert[num] = 5;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        five.GetComponent<Renderer>().material.color = Color.red;
                        c5 = 1;
                        insert[num] = 5;
                        num += 1;
                    }
                    else
                    {
                        five.GetComponent<Renderer>().material.color = Color.blue;
                        c5 = 1;
                        insert[num] = 5;
                        num += 1;
                    }
                }
                if (target.Equals(six) && c6 == 0)
                {
                    if (num == 0)
                    {
                        six.GetComponent<Renderer>().material.color = Color.yellow;
                        c6 = 1;
                        insert[num] = 6;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        six.GetComponent<Renderer>().material.color = Color.red;
                        c6 = 1;
                        insert[num] = 6;
                        num += 1;
                    }
                    else
                    {
                        six.GetComponent<Renderer>().material.color = Color.blue;
                        c6 = 1;
                        insert[num] = 6;
                        num += 1;
                    }
                }
                if (target.Equals(seven) && c7 == 0)
                {
                    if (num == 0)
                    {
                        seven.GetComponent<Renderer>().material.color = Color.yellow;
                        c7 = 1;
                        insert[num] = 7;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        seven.GetComponent<Renderer>().material.color = Color.red;
                        c7 = 1;
                        insert[num] = 7;
                        num += 1;
                    }
                    else
                    {
                        seven.GetComponent<Renderer>().material.color = Color.blue;
                        c7 = 1;
                        insert[num] = 7;
                        num += 1;
                    }
                }
                if (target.Equals(eight) && c8 == 0)
                {
                    if (num == 0)
                    {
                        eight.GetComponent<Renderer>().material.color = Color.yellow;
                        c8 = 1;
                        insert[num] = 8;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        eight.GetComponent<Renderer>().material.color = Color.red;
                        c8 = 1;
                        insert[num] = 8;
                        num += 1;
                    }
                    else
                    {
                        eight.GetComponent<Renderer>().material.color = Color.blue;
                        c8 = 1;
                        insert[num] = 8;
                        num += 1;
                    }
                }
                if (target.Equals(nine) && c9 == 0)
                {
                    if (num == 0)
                    {
                        nine.GetComponent<Renderer>().material.color = Color.yellow;
                        c9 = 1;
                        insert[num] = 9;
                        num += 1;
                    }
                    else if (num == 1)
                    {
                        nine.GetComponent<Renderer>().material.color = Color.red;
                        c9 = 1;
                        insert[num] = 9;
                        num += 1;
                    }
                    else
                    {
                        nine.GetComponent<Renderer>().material.color = Color.blue;
                        c9 = 1;
                        insert[num] = 9;
                        num += 1;
                    }
                }
            }

            else
            {
                target = GetClickedObject();
                if (target.Equals(button))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (answer[i] != insert[i])
                            wrong = 1;
                    }

                    if (wrong != 0)
                    {
                        wrong = 0;

                        one.GetComponent<Renderer>().material.color = Color.white;
                        two.GetComponent<Renderer>().material.color = Color.white;
                        three.GetComponent<Renderer>().material.color = Color.white;
                        four.GetComponent<Renderer>().material.color = Color.white;
                        five.GetComponent<Renderer>().material.color = Color.white;
                        six.GetComponent<Renderer>().material.color = Color.white;
                        seven.GetComponent<Renderer>().material.color = Color.white;
                        eight.GetComponent<Renderer>().material.color = Color.white;
                        nine.GetComponent<Renderer>().material.color = Color.white;

                        c1 = 0;
                        c2 = 0;
                        c3 = 0;
                        c4 = 0;
                        c5 = 0;
                        c6 = 0;
                        c7 = 0;
                        c8 = 0;
                        c9 = 0;

                        num = 0;
                    }
                    else
                    {
                        one.GetComponent<Renderer>().material.color = Color.green;
                        two.GetComponent<Renderer>().material.color = Color.green;
                        three.GetComponent<Renderer>().material.color = Color.green;
                        four.GetComponent<Renderer>().material.color = Color.green;
                        five.GetComponent<Renderer>().material.color = Color.green;
                        six.GetComponent<Renderer>().material.color = Color.green;
                        seven.GetComponent<Renderer>().material.color = Color.green;
                        eight.GetComponent<Renderer>().material.color = Color.green;
                        nine.GetComponent<Renderer>().material.color = Color.green;

                        c1 = 1;
                        c2 = 1;
                        c3 = 1;
                        c4 = 1;
                        c5 = 1;
                        c6 = 1;
                        c7 = 1;
                        c8 = 1;
                        c9 = 1;

                        if (opened == 0)
                        {
                            animator.SetTrigger("Activate");
                            opened = 1;
                        }

                        castle_key = 1;
                    }
                }
            }
        }
    }
}