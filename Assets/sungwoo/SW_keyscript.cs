using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SW_keyscript : CodeLock
{
    public GameObject SW_item;
    public GameObject SW_target;
    static int co = 0;
    Vector3 keySW_pos;

    public static int exit = 0;

    public static int collision = 0;

    void Key_Animation()
    {
        keySW_pos = this.transform.position;
        transform.Rotate(Vector3.one, 100 * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Key_Animation();
        if (Input.GetMouseButtonUp(0))
        {
            GW_target = GW_GetClickedObject();
            if (GW_target.tag == "key")
            {
                Destroy(GW_target);
                collision = 1;
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            if (collision == 0)
            {
                Debug.Log("충돌");
                Destroy(gameObject);
                keymove.currentscore++;
                exit = 1;
                collision = 1;
            }
        }
    }
}
