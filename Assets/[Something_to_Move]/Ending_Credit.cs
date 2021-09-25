using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CameraFading;         // CameraFade Asset

public class Ending_Credit : Ending_Credit_Timing
{
    public Text ending;

    Vector3 ending_pos;

    int ending_spped = 150;

    int ending_skip = 0;

    // Start is called before the first frame update
    void Start()
    {
        CameraFade.In(2f);
        end = 0;
        ending_skip = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ending_skip = 1;
            StartCoroutine(Ending());
        }

        if (end == 0)
        {
            ending_pos = this.transform.position;
            ending.transform.position = transform.position + Vector3.up * ending_spped * Time.deltaTime;  
        }
        else if(ending_skip == 0)
        {
            StartCoroutine(Ending2());
        }
    }

    IEnumerator Ending()
    {
        CameraFade.Out(2f);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    IEnumerator Ending2()
    {
        yield return new WaitForSeconds(5);
        CameraFade.Out(2f);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
}
