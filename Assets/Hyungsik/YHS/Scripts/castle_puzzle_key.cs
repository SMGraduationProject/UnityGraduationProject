using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_puzzle_key : castle_puzzle
{
    Vector3 castle_key_pos;

    void Key_Animation()
    {
        castle_key_pos = this.transform.position;

        if (castle_key_pos.y < 54)
        {
            transform.position = transform.position + Vector3.up * 1 * Time.deltaTime;
        }

        transform.Rotate(Vector3.one, 100 * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (castle_key == 1)
        {
            Key_Animation();

            if (Input.GetMouseButtonUp(0))
            {
                target = GetClickedObject();
                if (target.Equals(item))
                {
                    Destroy(item);
                }
            }
        }
    }
}
