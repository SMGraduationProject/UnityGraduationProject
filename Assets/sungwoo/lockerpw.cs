using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerpw : MonoBehaviour
{
    int pw;
    int inputCode;

    public string code = "";
    public string secondCode;

    public Transform toOpen;

    private void Start()
    {
        pw = code.Length;
    }
    void CheckCode()
    {
        if (secondCode == code)
        {
            StartCoroutine(Open());
        }
        else
        {
            Debug.Log("False");
        }
    }

    IEnumerator Open()
    {
        toOpen.Rotate(new Vector3(0, 90, 0), Space.World);

        yield return new WaitForSeconds(3);

        toOpen.Rotate(new Vector3(0, -90, 0), Space.World);
    }

    public void SetValue(string value)
    {
        inputCode++;
        if (inputCode <= pw)
        {
            secondCode += value;
        }

        if (inputCode == pw)
        {
            CheckCode();
            secondCode = "";
            inputCode = 0;
        }
    }
}