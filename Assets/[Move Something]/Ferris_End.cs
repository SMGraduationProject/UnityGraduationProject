using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CameraFading;         // CameraFade Asset

public class Ferris_End : Ferris_Start
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("End!!!!!");
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        CameraFade.Out(2f);
        yield return new WaitForSeconds(5);
        ferris_start = 0;
        keymove.currentscore = 0;
        SceneManager.LoadScene("Win");
    }
}
