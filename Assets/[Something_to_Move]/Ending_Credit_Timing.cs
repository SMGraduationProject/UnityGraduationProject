using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Credit_Timing : MonoBehaviour
{
    public static int end = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        end = 1;
        Debug.Log("Hello!");
    }
}
