using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GWkey_script : CodeLock
{
    public GameObject key;
    Vector3 GW_key_pos;
    Vector3 castle_key_cur_pos;
    void Key_Animation()
    {
        GW_key_pos = this.transform.position;

        if (GW_key_pos.y < 54)
        {
            //transform.position = transform.position + Vector3.up * 1 * Time.deltaTime;        //임의로 주석처리한 코드
        }

        transform.Rotate(Vector3.one, 100 * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        GW_key_pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GW_key == 1)
        {
            //Debug.Log("문제0");
            Key_Animation();
            //Debug.Log("문제1");
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("문제2");
                GW_target = GW_GetClickedObject();
                //Debug.Log("문제3");
                if (GW_target.Equals(key))
                {
                    //Debug.Log("문제4");
                    Destroy(key);
                   //Debug.Log("문제5");
                    keymove.currentscore++;
                    //Debug.Log("문제6");
                }
            }
        }

    }
}

