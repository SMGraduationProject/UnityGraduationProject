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
            "�̻��� ���� ���. ���̵��꿡 ���µ�, �������� ������� Ż���߰�,\n" +
            "�� ��Ȳ�ӿ����� ��Ե� �������� Ÿ�� �;� ���̱ⱸ���� ã�ƴٴϸ� ���踦 ������ �־���.";
        }
        if (check == 2)
        {
            OpeningText.text =
            "������ ���鼭 �ǹ� ��ġ�� Ȯ���ϰ� �� �ǹ����� ������ Ǯ� ���踦 ���� �Ѵ�.\n" +
            "���踦 ���� ȹ���� �� �������� �̵��ϰ� ž���϶�.";
        }
        if (check == 3)
        {
            OpeningText.text =
            "M_R: Ŭ��\n" +
            "M_L: ����\n" +
            "wasd: �̵�\n" +
            "space: ����\n" +
            "shift: �޸���\n" +
            "ctrl: �ɱ�, ��ǻ�� ȭ�� ����\n" +
            "e: ��ǻ�� ȭ�� ����";
        }
        if (check == 4)
        {
            SceneManager.LoadScene(2);
        }
    }
}
