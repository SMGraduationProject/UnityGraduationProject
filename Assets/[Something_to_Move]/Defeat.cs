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
            "����� �浹�ϰ� ���� �޿��� ������. ";
        }
        if (check == 2)
        {
            DefeatText.text =
            "�ٽ� �����ص� ������ ���̾���,\n" +
            "�Ϸ����� ������ ����� ���ĳ� �� ������.";
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
