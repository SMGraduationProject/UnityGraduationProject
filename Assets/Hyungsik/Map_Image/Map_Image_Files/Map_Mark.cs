using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Mark : MonoBehaviour
{
    public GameObject Player;
    public GameObject Marker;
    public GameObject Map;

    Vector3 Player_pos;
    Vector3 Marker_Y;

    Quaternion Player_rot;
    Quaternion Marker_rot;

    // Start is called before the first frame update
    void Start()
    {
        Marker_Y = Marker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Player_pos = Player.transform.position;
        Player_rot = Player.transform.rotation;
        Marker_rot = Marker.transform.rotation;

        Marker.transform.position = new Vector3(Player_pos.x, Marker_Y.y, Player_pos.z);
        Map.transform.position = new Vector3(Player_pos.x, Marker_Y.y + 500, Player_pos.z);

        if(Input.GetMouseButton(1))
        {
            Map.transform.position = new Vector3(Player_pos.x, Player_pos.y, Player_pos.z);
        }
    }
}
