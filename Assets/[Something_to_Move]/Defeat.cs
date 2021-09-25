using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CameraFading;         // CameraFade Asset

public class Defeat : MonoBehaviour
{
    int check = 1;
    public Text DefeatText = null;

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
            DefeatText.text =
            "공룡과 충돌하고 나는 꿈에서 깨었다. ";
        }
        if (check == 2)
        {
            DefeatText.text =
            "다시 생각해도 괴상한 꿈이었고,\n" +
            "하루종일 찝찝한 기분을 떨쳐낼 수 없었다.";
        }
        if (check == 3)
        {
            DefeatText.text =
            "GameOver";
        }
        if (check == 4)
        {
            SceneManager.LoadScene(0);
        }
    }
}
