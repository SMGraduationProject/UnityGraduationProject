using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_boat : MonoBehaviour
{
    public GameObject boat;
    public GameObject player;

    Vector3 player_pos;
    Vector3 boat_pos;
    Vector3 boat_pos_cur;
    Quaternion boat_rot;
    Quaternion boat_rot_cur;

    int boat_speed = 3;
    int boat_rotation = 50;

    int start = 0;
    int point_1 = 0;
    int point_2 = 0;
    int point_3 = 0;
    int point_4 = 0;
    int point_5 = 0;

    public GameObject target;

    public GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //마우스 포인트 근처 좌표를 만든다. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }

    // Start is called before the first frame update
    void Start()
    {
        boat_pos = this.transform.position;
        boat_rot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            target = GetClickedObject();
            player_pos = player.transform.position;
            boat_pos_cur = this.transform.position;
            boat_rot_cur = this.transform.rotation;

            if (target.Equals(boat) && start == 0)
            {
                start = 1;
                point_1 = 1;
            }
        }

        if (point_1 == 1)
        {      
            if(boat_pos_cur.x <= boat_pos.x + 15)
            {
                boat_pos_cur = this.transform.position;
                transform.position = transform.position + Vector3.right * boat_speed * Time.deltaTime;
                player.transform.position = transform.position;
            }
            else
            {
                if(boat_rot_cur.y >= boat_rot.y - 0.285)
                {
                    boat_rot_cur = this.transform.rotation;
                    transform.Rotate(Vector3.down, boat_rotation * Time.deltaTime);
                    player.transform.position = transform.position;
                }
                else
                {
                    point_1 = 0;
                    point_2 = 1;
                }
            }
        }

        if (point_2 == 1)
        {
            if (boat_pos_cur.z <= boat_pos.z + 20)
            {
                boat_pos_cur = this.transform.position;
                transform.position = transform.position + Vector3.forward * boat_speed * Time.deltaTime;
                player.transform.position = transform.position;
            }
            else
            {
                if (boat_rot_cur.y >= boat_rot.y - 0.975)
                {
                    boat_rot_cur = this.transform.rotation;
                    transform.Rotate(Vector3.down, boat_rotation * Time.deltaTime);
                    player.transform.position = transform.position;
                }
                else
                {
                    point_2 = 0;
                    point_3 = 1;
                }
            }
        }

        if (point_3 == 1)
        {
            if (boat_pos_cur.x >= boat_pos.x - 4)
            {
                boat_pos_cur = this.transform.position;
                transform.position = transform.position + Vector3.left * boat_speed * Time.deltaTime;
                player.transform.position = transform.position;
            }
            else
            {
                if (boat_rot_cur.y >= boat_rot.y - 1.7)
                {
                    boat_rot_cur = this.transform.rotation;
                    transform.Rotate(Vector3.down, boat_rotation * Time.deltaTime);
                    player.transform.position = transform.position;
                }
                else
                {
                    point_3 = 0;
                    point_4 = 1;
                }
            }
        }

        if (point_4 == 1)
        {

            if (boat_pos_cur.z >= boat_pos.z)
            {
                boat_pos_cur = this.transform.position;
                transform.position = transform.position + Vector3.back * boat_speed * Time.deltaTime;
                player.transform.position = transform.position;
            }
            else
            {
                if (boat_rot_cur.y >= boat_rot.y - 1.99)
                {
                    boat_rot_cur = this.transform.rotation;
                    transform.Rotate(Vector3.down, boat_rotation * Time.deltaTime);
                    player.transform.position = transform.position;
                }
                else
                {
                    boat_pos_cur.z = boat_pos.z;
                    this.transform.rotation = boat_rot;
                    point_4 = 0;
                    point_5 = 1;
                }
            }
        }

        if (point_5 == 1)
        {
            if (boat_pos_cur.x <= boat_pos.x)
            {
                boat_pos_cur = this.transform.position;
                transform.position = transform.position + Vector3.right * boat_speed * Time.deltaTime;
                player.transform.position = transform.position;
            }
            else
            {
                this.transform.position = boat_pos;
                this.transform.rotation = boat_rot;
                player.transform.position = player_pos;
                point_5 = 0;
                start = 0;
            }
        }
    }
}
