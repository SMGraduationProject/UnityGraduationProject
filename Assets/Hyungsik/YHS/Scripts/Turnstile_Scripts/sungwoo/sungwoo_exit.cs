using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungwoo_exit : MonoBehaviour     // 테스트 플레이 후 개찰구가 열려져 있는것을 확인한 후 개인 키 스크립트 상속시킬 것.
{
    Quaternion Turnstile_rot;
    Quaternion Turnstile_cur_rot;

    int exit = 1;                           // 테스트를 위한 변수. 테스트 플레이 후 개찰구가 열려져 있는것을 확인했다면 삭제할 것.
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
        if (exit == 1)              // 키 스크립트의 전역변수명이 exit가 아닐경우 변경할 것.
        {
            if(exit_opened == 0)
            {
                Turnstile_Animation();
            }
}
    }
}
