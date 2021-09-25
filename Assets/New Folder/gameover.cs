using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject Enemy;

    public static int all_collect = 0;

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
            Destroy(Enemy);
            all_collect = 1;
        }
    }
}
