using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_puzzle_exit : castle_puzzle_key
{
    private Animator animator;
    int exit_opened = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(exit == 1)
        {
            if(exit_opened == 0)
            {
                animator.SetTrigger("Activate");
                exit_opened = 1;
            }
}
    }
}
