using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 이 스크립트를 적용하기 전 여러분들의 스크립트에 이 스크립트를 작동시킬 수 있는 전역 변수를 0으로 선언하여 하나 추가하시기 바랍니다. 
   또한 이 스크립트의 스크립트 명 castle_puzzle_chest 또한 여러분들의 퍼즐 이름에 맞게 변경하여 사용하시기 바랍니다.

   전역변수는 다음과 같이 추가하면 됩니다. (물론 변수명은 여러분들의 퍼즐 이름에 맞게 변경하셔야 합니다.)
   public static int castle_chest = 0;
   public static int castle_key = 0; 

   작동은 여러분들 퍼즐 스크립트에서 조건을 만족했을때의 조건식 안에 다음과 같이 추가하시면 됩니다.
   castle_chest = 1; (castle_key = 1 의 경우에는 castle_puzzle_chest 안에 선언되어 있습니다.);

   chest의 경우 인스펙터(Inspector)에 추가할 것은 없습니다. 다만 key의 경우 하이어라키(hierarchy)에 있는 rust_key를 인스펙터의 key에 추가하여 주시기 바랍니다.
*/

public class port_reward_chest : FakeTerminal              // 상속할 스크립트는 castle_puzzle 대신 여러분들의 퍼즐 스크립트를 넣으시면 되며 그 스크립트 안에 이 스크립트를 작동시킬 전역변수를 하나 선언하시면 됩니다.
{
    private Animator animator;          // 박스 애니메이션 작동을 위한 애니메이터 추가

    int opened = 0;         // 박스가 열렸는지를 확인하기 위한 변수

    private void Awake()        // 애니메이션 관련 함수
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (port_chest == 1)      // 전역변수에 1을 추가하여 조건식을 이용해 애니메이션을 작동시킵니다. 전역변수명은 여러분이 지정한 변수명을 사용하면 됩니다.
        {
            if(opened == 0)         // 박스가 열렸는지를 확인하기 위한 조건문
            {
                animator.SetTrigger("Activate");        // 박스 애니메이션 작동
                opened = 1;         // 더이상의 작동을 중지시키기 위해 opened 변수를 1로 설정

                port_key = 1;     // 전역변수에 1을 추가하여 key 스크립트를 작동시킵니다. 전역변수명은 여러분이 지정한 변수명을 사용하면 됩니다.
            }
        }
    }
}
