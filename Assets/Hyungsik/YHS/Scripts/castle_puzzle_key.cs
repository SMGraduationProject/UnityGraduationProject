using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* �� ��ũ��Ʈ�� �����ϱ� �� �����е��� ��ũ��Ʈ�� �� ��ũ��Ʈ�� �۵���ų �� �ִ� ���� ������ 0���� �����Ͽ� �ϳ� �߰��Ͻñ� �ٶ��ϴ�. 
   ���� �� ��ũ��Ʈ�� ��ũ��Ʈ �� castle_puzzle_chest ���� �����е��� ���� �̸��� �°� �����Ͽ� ����Ͻñ� �ٶ��ϴ�.

   ���������� ������ ���� �߰��ϸ� �˴ϴ�. (���� �������� �����е��� ���� �̸��� �°� �����ϼž� �մϴ�.)
   public static int castle_chest = 0;
   public static int castle_key = 0; 

   �۵��� �����е� ���� ��ũ��Ʈ���� ������ ������������ ���ǽ� �ȿ� ������ ���� �߰��Ͻø� �˴ϴ�.
   castle_chest = 1; (castle_key = 1 �� ��쿡�� castle_puzzle_chest �ȿ� ����Ǿ� �ֽ��ϴ�.);

   chest�� ��� �ν�����(Inspector)�� �߰��� ���� �����ϴ�. �ٸ� key�� ��� ���̾��Ű(hierarchy)�� �ִ� rust_key�� �ν������� key�� �߰��Ͽ� �ֽñ� �ٶ��ϴ�.
*/

public class castle_puzzle_key : castle_puzzle_chest      // ����� ��ũ��Ʈ�� castle_puzzle_chest�� �̸��� �����Ͽ� �����ø� �˴ϴ�.
{
    public GameObject key;          // Ű ���� ������Ʈ. �ν����� â���� key �׸� ���̾Ű�� rust_key ������Ʈ�� �߰��ϼ���.
    //public GameObject target;       // ���콺�� Ŭ���� ����� Ű������ Ȯ���ϱ� ���� ���� ������Ʈ. Ű���� Ŭ������ �ٲٽ÷��� �ٸ� ���� ������Ʈ�� ����ϼŵ� �˴ϴ�. ���� ���� �̹� �ֱ⿡ �ּ� ó�� �Ͽ����ϴ�.

    Vector3 castle_key_pos;             // Ű�� �ʱ� ��ġ�� ���� ����
    Vector3 castle_key_cur_pos;         // Ű�� �ǽð� ��ġ�� ���� ����

    public static int exit;         // ������ �۵��� ���� ��������. ������ ���� �ڵ�� ������ �߰��Ұ��Դϴ�.

    /*public GameObject GetClickedObject()        // Ű�� Ŭ���ϱ� ���� �ʿ��� �Լ�. ���콺 Ŭ���� �ƴ϶� Ű���� Ŭ������ �ٲٽ÷��� �ٸ� �Լ��� ����ϼ���. ���������� ���� �̹� �ֱ⿡ �ּ� ó�� �Ͽ����ϴ�.
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //���콺 ����Ʈ ��ó ��ǥ�� �����. 

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))   //���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
        {
            //������ ������Ʈ�� �����Ѵ�.
            target = hit.collider.gameObject;
        }
        return target;
    }
    */

    void Key_Animation()        // Ű�� �������� ���� �Լ�
    {
        castle_key_cur_pos = this.transform.position;       // Ű�� �ǽð� ��ġ�� ������Ʈ ��Ű�� �ڵ�

        if (castle_key_cur_pos.y < castle_key_pos.y + 1)        // Ű�� �ǽð� ��ġ�� �ʱ� ��ġ�� ���� �󸶳� �������� �˻��ϴ� ���ǹ�. ������ �ٲٷ��� y�� �ٸ������� �ٲٸ� �˴ϴ�.
        {
            transform.position = transform.position + Vector3.up * 1 * Time.deltaTime;      // Ű�� �̵���Ű�� �Լ�, ������ �ٲٷ��� up�� �ٸ� ������ �ٲٸ� �˴ϴ�.
        }

        transform.Rotate(Vector3.one, 100 * Time.deltaTime);        // Ű�� ȸ����Ű�� �Լ�. �ٲٷ��� one �κ��� �ٸ������� �ٲٸ� �˴ϴ�.
    }

    // Start is called before the first frame update
    void Start()
    {
        castle_key_pos = this.transform.position;           // Ű�� �ʱ� ��ġ�� �����Ű�� �ڵ�.
    }

    // Update is called once per frame
    void Update()
    {
        if (castle_key == 1)                // �����Ϸ��� castle_key�κ��� �����е��� �����Ų ������������ ��� ���ø� �˴ϴ�.
        {
            Key_Animation();        // Ű�� �������� ���� �Լ�

            if (Input.GetMouseButtonUp(0))      // ���콺 Ŭ���� �۵��ϴ� ���ǹ�. ������ ����� ��� Ű����� �ٲٷ��� �����е��� ������� ����Ͻø� �˴ϴ�.
            {
                target = GetClickedObject();        // ���콺�� Ŭ���Ѱ��� Ű������ Ȯ���ϱ� ���� �ڵ�
                if (target.Equals(key))             // ���콺�� Ŭ���Ѱ��� Ű������ Ȯ���ϱ� ���� ���ǽ�
                {
                    Destroy(key);       // Ű�� �����ϱ� ���� �ڵ�. Ű�� ������ �߰��ϴ� �ڵ�� �Ʒ��� ������ �ɰ̴ϴ�.
                    // map_key = map_key + 1; �̷������� ���Դϴ�.
                    exit = 1;           // ������ �۵��� ���� ���������� 1 �߰�. ������ ���� �ڵ�� ������ �߰��Ұ��Դϴ�.
                }
            }
        }
    }
}
