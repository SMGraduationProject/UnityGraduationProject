using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CameraFading;         // CameraFade Asset

public class Opening : MonoBehaviour
{
    int check = 1;
    public Text OpeningText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            check += 1;
        }

        if (check == 1)
        {
            OpeningText.text =
            "이상한 꿈을 꿨다. 놀이동산에 갔는데, 동물원의 공룡들이 탈출했고,\n" +
            "그 상황속에서도 어떻게든 관람차를 타고 싶어 놀이기구들을 찾아다니며 열쇠를 모으고 있었다.";
        }
        if (check == 2)
        {
            OpeningText.text =
            "지도를 보면서 건물 위치를 확인하고 각 건물에서 퍼즐을 풀어서 열쇠를 얻어야 한다.\n" +
            "열쇠를 전부 획득한 후 관람차로 이동하고 탑승하라.";
        }
        if (check == 3)
        {
            OpeningText.text =
            "M_R: 클릭\n" +
            "M_L: 지도\n" +
            "wasd: 이동\n" +
            "space: 점프\n" +
            "shift: 달리기\n" +
            "ctrl: 앉기, 컴퓨터 화면 종료\n" +
            "e: 컴퓨터 화면 입장";
        }
        if (check == 4)
        {
            SceneManager.LoadScene(2);
        }
    }
}
