using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keymove : MonoBehaviour
{
    public Text keyscoreText;
    public static int currentscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keyscoreText.text = currentscore.ToString();
    }
}