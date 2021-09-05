using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    CodeLock CodeLock;
    int reachRange = 100;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
        }
    }
    void CheckHitObj()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, reachRange))
        {
            CodeLock = hit.transform.gameObject.GetComponentInParent<CodeLock>();

            if (CodeLock != null)
            {
                string value = hit.transform.name;
                CodeLock.SetValue(value);
            }
        }
    }
}
