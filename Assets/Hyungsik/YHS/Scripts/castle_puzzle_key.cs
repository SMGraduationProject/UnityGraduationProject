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

public class castle_puzzle_key : castle_puzzle_chest      // 상속할 스크립트는 castle_puzzle_chest의 이름을 변경하여 넣으시면 됩니다.
{
    public GameObject key;          // 키 게임 오브젝트. 인스펙터 창에서 key 항목에 하이어리키의 rust_key 오브젝트를 추가하세요.
    //public GameObject target;       // 마우스가 클릭한 대상이 키인지를 확인하기 위한 게임 오브젝트. 키보드 클릭으로 바꾸시려면 다른 게임 오브젝트를 사용하셔도 됩니다. 저는 퍼즐에 이미 있기에 주석 처리 하였습니다.

    Vector3 castle_key_pos;             // 키의 초기 위치를 위한 변수
    Vector3 castle_key_cur_pos;         // 키의 실시간 위치를 위한 변수

    public static int exit;         // 개찰구 작동을 위한 전역변수. 개찰구 관련 코드는 별도로 추가할것입니다.

    /*public GameObject GetClickedObject()        // 키를 클릭하기 위해 필요한 함수. 마우스 클릭이 아니라 키보드 클릭으로 바꾸시려면 다른 함수를 사용하세요. 마찬가지로 퍼즐에 이미 있기에 주석 처리 하였습니다.
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
    */

    void Key_Animation()        // 키의 움직임을 위한 함수
    {
        castle_key_cur_pos = this.transform.position;       // 키의 실시간 위치를 업데이트 시키는 코드

        if (castle_key_cur_pos.y < castle_key_pos.y + 1)        // 키의 실시간 위치가 초기 위치에 비해 얼마나 높은가를 검사하는 조건문. 방향을 바꾸려면 y를 다른것으로 바꾸면 됩니다.
        {
            transform.position = transform.position + Vector3.up * 1 * Time.deltaTime;      // 키를 이동시키는 함수, 방향을 바꾸려면 up을 다른 것으로 바꾸면 됩니다.
        }

        transform.Rotate(Vector3.one, 100 * Time.deltaTime);        // 키를 회전시키는 함수. 바꾸려면 one 부분을 다른것으로 바꾸면 됩니다.
    }

    // Start is called before the first frame update
    void Start()
    {
        castle_key_pos = this.transform.position;           // 키의 초기 위치를 적용시키는 코드.
    }

    // Update is called once per frame
    void Update()
    {
        if (castle_key == 1)                // 시작하려면 castle_key부분을 여러분들이 변경시킨 전역변수명을 대신 쓰시면 됩니다.
        {
            Key_Animation();        // 키의 움직임을 위한 함수

            if (Input.GetMouseButtonUp(0))      // 마우스 클릭시 작동하는 조건문. 위에서 언급한 대로 키보드로 바꾸려면 여러분들이 변경시켜 사용하시면 됩니다.
            {
                target = GetClickedObject();        // 마우스로 클릭한것이 키인지를 확인하기 위한 코드
                if (target.Equals(key))             // 마우스로 클릭한것이 키인지를 확인하기 위한 조건식
                {
                    Destroy(key);       // 키를 삭제하기 위한 코드. 키의 갯수를 추가하는 코드는 아래에 넣으면 될겁니다.
                    // map_key = map_key + 1; 이런식으로 말입니다.
                    exit = 1;           // 개찰구 작동을 위해 전역변수에 1 추가. 개찰구 관련 코드는 별도로 추가할것입니다.
                }
            }
        }
    }
}
