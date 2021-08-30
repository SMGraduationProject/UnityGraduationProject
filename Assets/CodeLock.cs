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
        }
    }

    IEnumerator Open()
    {
        toOpen.Rotate(new Vector3(0, 90, 0), Space.World);

        yield return new WaitForSeconds(4);

        toOpen.Rotate(new Vector3(0, -90, 0), Space.World);
    }
   
    public void SetValue(string value)
    {
        placeInCode++;
        if (placeInCode <= codeLength)
        {
            attemptedCode += value;
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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            GW_target = hit.collider.gameObject;
        }
        return GW_target;
    }
}
