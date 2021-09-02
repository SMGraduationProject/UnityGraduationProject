using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerpw : MonoBehaviour
{
    int codeLength;
    int placeInCode;
    public GameObject SW_item;
    public GameObject SW_target;
    public string code = "";
    public string attemptedCode;
    public Transform toOpen;

    private void Start()
    {
        codeLength = code.Length;
    }
    void CheckCode()
    {
        if (attemptedCode == code)
        {
            StartCoroutine(Open());
        }
        else
        {
            Debug.Log("잘못된 코드입니다");
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

        if (placeInCode == codeLength)
        {
            CheckCode();
            attemptedCode = "";
            placeInCode = 0;
        }
    }
     public GameObject SW_GetClickedObject()
    {
        RaycastHit hit;
        GameObject SW_target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   
        {
            SW_target = hit.collider.gameObject;
        }
        return SW_target;
    }
}