using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel_Rotation : Ferris_Start
{

    public  float speed;
    
        
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ferris_start == 1)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        } 
    }
}
