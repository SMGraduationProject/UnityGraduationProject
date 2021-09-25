using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferris_Pos : Ferris_Start
{
    public GameObject player;

    Vector3 player_pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ferris_start == 1)
        {
            player.transform.position = transform.position;
        }
    }
}
