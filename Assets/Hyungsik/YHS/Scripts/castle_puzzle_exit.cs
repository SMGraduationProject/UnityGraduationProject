using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_puzzle_exit : castle_puzzle_key
{
    Quaternion Turnstile_rot;
    Quaternion Turnstile_cur_rot;

    int exit_opened = 0;

    void Turnstile_Animation()
    {
        Turnstile_cur_rot = this.transform.rotation;

        if (Turnstile_cur_rot.y > Turnstile_rot.y - 0.3)
        {
            Turnstile_cur_rot = this.transform.rotation;
            transform.Rotate(Vector3.down, 50 * Time.deltaTime);
        }
        else
            exit_opened = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Turnstile_rot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (exit == 1)
        {
            if(exit_opened == 0)
            {
                Turnstile_Animation();
            }
}
    }
}
