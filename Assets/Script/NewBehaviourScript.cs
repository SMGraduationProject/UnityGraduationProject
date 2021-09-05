using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;

    Vector3 moveVec;


    void Start()
    {
       

    }
    void Update()
    {

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
         if (transform.position.x > -13 && transform.position.x < -2)
        {
            if (transform.position.z < 70 && transform.position.z > 58 && transform.position.y == -1)
            {
                transform.position = new Vector3(2, -1, 20);

            }

        }
        else if (transform.position.x > 5 && transform.position.x < 15)
        {
            if (transform.position.z < 70 && transform.position.z > 58 && transform.position.y == -1)
            {
                transform.position = new Vector3(2, -1, 20);

            }

        }
        else if (transform.position.x > -22 && transform.position.x < 30)
        {
            if (transform.position.z < 70 && transform.position.z > 58 && transform.position.y == -1)
            {
                transform.position = new Vector3(2, -1, 20);

            }

        }
        else if (transform.position.x > -27 && transform.position.x < -17)
        {
            if (transform.position.z < 70 && transform.position.z > 58 && transform.position.y == -1)
            {
                transform.position = new Vector3(2, -1, 75);

            }

        }
    }
}

