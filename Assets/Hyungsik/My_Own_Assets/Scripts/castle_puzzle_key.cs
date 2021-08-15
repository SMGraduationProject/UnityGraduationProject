using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_puzzle_key : castle_puzzle
{
    Vector3 key_pos;
    Vector3 key_height;

    // Start is called before the first frame update
    void Start()
    {
        key_height = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (key == 1)
        {
            key_pos = this.transform.position;

            if(key_pos.y < key_height.y + 1)
            {
                transform.position = transform.position + Vector3.up * 1 * Time.deltaTime;
            }
                    
            transform.Rotate(Vector3.one, 100 * Time.deltaTime);

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
