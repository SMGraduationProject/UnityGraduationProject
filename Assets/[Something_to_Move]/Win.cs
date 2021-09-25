using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CameraFading;         // CameraFade Asset

public class Win : MonoBehaviour
{
    int check = 1;
    public Text WinText = null;

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
            WinText.text =
            "관람차를 타면서 나는 어린시절의 추억을 떠올렸다. ";
        }
        if (check == 2)
        {
            WinText.text =
            "괴상한 꿈이었지만,\n" +
            "어째선지 기분은 홀가분 했다.";
        }
        if (check == 3)
        {
            WinText.text =
            "오늘 하루는 기분좋게 보낼 수 있을듯한 느낌이 든다.";
        }
        if (check == 4)
        {
            SceneManager.LoadScene(5);
        }
    }
}
