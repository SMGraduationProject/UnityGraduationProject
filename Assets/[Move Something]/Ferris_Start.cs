using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferris_Start : gameover
{
    public static int ferris_start = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(all_collect == 1)
        {
            ferris_start = 1;
            all_collect = 0;
        }      
    }
}
