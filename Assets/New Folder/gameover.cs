using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(keymove.currentscore == 5)
        {
	Debug.Log("게임 종료");
            SceneManager.LoadScene("GameOver1");
        }
    }
}
