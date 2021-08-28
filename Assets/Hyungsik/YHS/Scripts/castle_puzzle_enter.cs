using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_puzzle_enter : MonoBehaviour
{
    public GameObject player;

    Vector3 p_pos;

    Vector3 Turnstile_pos;
    Quaternion Turnstile_rot;
    Quaternion Turnstile_cur_rot;

    Vector3 x1;
    Vector3 x2;
    Vector3 z1;
    Vector3 z2;

    int enter = 0;


    void Turnstile_Animation()
    {
        Turnstile_cur_rot = this.transform.rotation;

        if (Turnstile_cur_rot.y > Turnstile_rot.y - 0.29)
        {
            Turnstile_cur_rot = this.transform.rotation;
            transform.Rotate(Vector3.down, 50 * Time.deltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Turnstile_pos = this.transform.position;
        Turnstile_rot = this.transform.rotation;

        x1 = Turnstile_pos;
        x2 = Turnstile_pos;
        z1 = Turnstile_pos;
        z2 = Turnstile_pos;

        x1.x = Turnstile_pos.x - 2;
        x2.x = Turnstile_pos.x + 2;
        z1.z = Turnstile_pos.z - 2;
        z2.z = Turnstile_pos.z + 2;
    }

    // Update is called once per frame
    void Update()
    {
        p_pos = player.transform.position;

        if (p_pos.z > z1.z && p_pos.z < z2.z)
        {
            if (p_pos.x > x1.x && p_pos.x < x2.x)
            {
                enter = 1;
            }
        }

        if (enter == 1)
        {
            Turnstile_Animation();
        }  
    }
}
