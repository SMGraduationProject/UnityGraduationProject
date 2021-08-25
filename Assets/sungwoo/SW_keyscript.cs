using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SW_keyscript : CodeLock
{  
    public static int SW_key = 0; 
    Vector3 SWkey_pos;

    void Key_Animation()
    {
        SWkey_pos = this.transform.position;

        if (SWkey_pos.y < 54)
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
        if (SW_key == 1)
        {
            Key_Animation();

            if (Input.GetMouseButtonUp(0))
            {
                GW_target = GW_GetClickedObject();
                if (GW_target.Equals(GW_item))
                {
                    Destroy(GW_item);
                }
            }
        }
    }
}
