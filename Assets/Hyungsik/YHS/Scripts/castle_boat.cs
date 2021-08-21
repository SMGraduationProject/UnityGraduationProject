using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castle_boat : MonoBehaviour
{
    public GameObject boat;
    public GameObject player;
    public GameObject way1;
    public GameObject way2;
    public GameObject way3;
    public GameObject way4;
    public GameObject way5;
    public GameObject end;

    Vector3 player_pos;

    Vector3 boat_pos;
    Vector3 boat_pos_cur;
    Quaternion boat_rot;
    Quaternion boat_rot_cur;

    Vector3 way1_pos;
    Quaternion way1_rot;
    Vector3 way2_pos;
    Quaternion way2_rot;
    Vector3 way3_pos;
    Quaternion way3_rot;
    Vector3 way4_pos;
    Quaternion way4_rot;
    Vector3 way5_pos;
    Quaternion way5_rot;

    Vector3 end_pos;


    int boat_speed = 3;
    int boat_rotation = 50;

    int start = 0;
    int point_1 = 0;
    int point_2 = 0;
    int point_3 = 0;
    int point_4 = 0;
    int point_5 = 0;
    int point_6 = 0;

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

    public void Current_Position()
    {
        boat_pos_cur = this.transform.position;
        player.transform.position = transform.position;
    }
  
    public void Rotate_Boat()
    {
        boat_rot_cur = this.transform.rotation;
        player.transform.position = transform.position;
        transform.Rotate(Vector3.down, boat_rotation * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        boat_pos = this.transform.position;
        boat_rot = this.transform.rotation;
        way1_pos = way1.transform.position;
        way1_rot = way1.transform.rotation;
        way2_pos = way2.transform.position;
        way2_rot = way2.transform.rotation;
        way3_pos = way3.transform.position;
        way3_rot = way3.transform.rotation;
        way4_pos = way4.transform.position;
        way4_rot = way4.transform.rotation;
        way5_pos = way5.transform.position;
        way5_rot = way5.transform.rotation;
        end_pos = end.transform.position;
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
            if(boat_pos_cur.x > way1_pos.x)
            {
                Current_Position();
                transform.position = Vector3.MoveTowards(transform.position, way1_pos, boat_speed * Time.deltaTime);
            }
            else
            {
                if(boat_rot_cur.y < way1_rot.y)
                {
                    Rotate_Boat();
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
            if (boat_pos_cur.z > way2_pos.z)
            {
                Current_Position();
                transform.position = Vector3.MoveTowards(transform.position, way2_pos, boat_speed * Time.deltaTime);
            }
            else
            {
                if (boat_rot_cur.y < way2_rot.y - 0.001)
                {
                    Rotate_Boat();
                }
                else
                {
                    this.transform.rotation = way2_rot;
                    point_2 = 0;
                    point_3 = 1;
                }
            }
        }

        if (point_3 == 1)
        {
            if (boat_pos_cur.x < way3_pos.x)
            {
                Current_Position();
                transform.position = Vector3.MoveTowards(transform.position, way3_pos, boat_speed * Time.deltaTime);
            }
            else
            {
                if (boat_rot_cur.y > way3_rot.y)
                {
                    Rotate_Boat();
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

            if (boat_pos_cur.z < way4_pos.z)
            {
                Current_Position();
                transform.position = Vector3.MoveTowards(transform.position, way4_pos, boat_speed * Time.deltaTime);
            }
            else
            {
                if (boat_rot_cur.y > way4_rot.y)
                {
                    Rotate_Boat();
                }
                else
                {
                    point_4 = 0;
                    point_5 = 1;
                }
            }
        }

        if (point_5 == 1)
        {

            if (boat_pos_cur.x > way5_pos.x)
            {
                Current_Position();
                transform.position = Vector3.MoveTowards(transform.position, way5_pos, boat_speed * Time.deltaTime);
            }
            else
            {
                player_pos = player.transform.position;
                if (player_pos.z < end_pos.z)
                {
                    Debug.Log("Hello!");
                    player.transform.position = Vector3.MoveTowards(player.transform.position, end_pos, boat_speed * Time.deltaTime);
                    //player.transform.position = end_pos;
                }
                else
                {
                    point_5 = 0;
                    point_6 = 1;
                }           
            }
        }

        if (point_6 == 1)
        {
            if (boat_pos_cur.x > boat_pos.x)
            {
                boat_pos_cur = this.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, boat_pos, boat_speed * Time.deltaTime);
            }
            else
            {
                this.transform.position = boat_pos;
                this.transform.rotation = boat_rot;
                point_6 = 0;
                start = 0;
            }
        }
    }
}
