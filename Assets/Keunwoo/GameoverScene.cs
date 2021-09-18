using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScene : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            keymove.currentscore = 0;       //추가된 코드
            SceneManager.LoadScene(0);
        }
    }
}
