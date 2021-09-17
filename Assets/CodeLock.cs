using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeLock : MonoBehaviour
{

    int codeLength;
    int placeInCode;
    public GameObject GW_item;
    public GameObject GW_target;
    public string code = "";
    public string attemptedCode;
    public static int GW_key = 0;
    public Transform toOpen;

    public GameObject check;        //�߰��� �ڵ�

    private void Start()
    {
        codeLength = code.Length;
    }

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            StartCoroutine(Open());
            GW_key = 1;
            //Debug.Log("tempt");
            //keymove.currentscore = keymove.currentscore - 1;
        }
        else
        {
            Debug.Log("Wrong Code");
            check.GetComponent<Renderer>().material.color = Color.red;          //�߰��� �ڵ�
        }
    }

    IEnumerator Open()
    {
        toOpen.Rotate(new Vector3(0, 90, 0), Space.World);
        check.SetActive(false);         //�߰��� �ڵ�

        yield return new WaitForSeconds(4);

        toOpen.Rotate(new Vector3(0, -90, 0), Space.World);
        check.SetActive(true);         //�߰��� �ڵ�
    }
   
    public void SetValue(string value)
    {
        placeInCode++;
        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
            check.GetComponent<Renderer>().material.color = Color.white;      //�߰��� �ڵ�
        }

        if(placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
    public GameObject GW_GetClickedObject()
    {
        RaycastHit hit;
        GameObject GW_target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���콺 ����Ʈ ��ó ��ǥ�� �����. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
        {
            //������ ������Ʈ�� �����Ѵ�.
            GW_target = hit.collider.gameObject;
        }
        return GW_target;
    }
}
