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
            "�������� Ÿ�鼭 ���� ������� �߾��� ���÷ȴ�. ";
        }
        if (check == 2)
        {
            WinText.text =
            "������ ���̾�����,\n" +
            "��°���� ����� Ȧ���� �ߴ�.";
        }
        if (check == 3)
        {
            WinText.text =
            "���� �Ϸ�� ������� ���� �� �������� ������ ���.";
        }
        if (check == 4)
        {
            SceneManager.LoadScene(5);
        }
    }
}
