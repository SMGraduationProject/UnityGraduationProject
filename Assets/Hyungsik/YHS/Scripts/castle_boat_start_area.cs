using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_boat_start_area : MonoBehaviour
{
    public static int boat_start = 0;

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
        boat_start = 1;
    }
}
