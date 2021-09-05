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

public class port_reward_chest : FakeTerminal              // ����� ��ũ��Ʈ�� castle_puzzle ��� �����е��� ���� ��ũ��Ʈ�� �����ø� �Ǹ� �� ��ũ��Ʈ �ȿ� �� ��ũ��Ʈ�� �۵���ų ���������� �ϳ� �����Ͻø� �˴ϴ�.
{
    private Animator animator;          // �ڽ� �ִϸ��̼� �۵��� ���� �ִϸ����� �߰�

    int opened = 0;         // �ڽ��� ���ȴ����� Ȯ���ϱ� ���� ����

    private void Awake()        // �ִϸ��̼� ���� �Լ�
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (port_chest == 1)      // ���������� 1�� �߰��Ͽ� ���ǽ��� �̿��� �ִϸ��̼��� �۵���ŵ�ϴ�. ������������ �������� ������ �������� ����ϸ� �˴ϴ�.
        {
            if(opened == 0)         // �ڽ��� ���ȴ����� Ȯ���ϱ� ���� ���ǹ�
            {
                animator.SetTrigger("Activate");        // �ڽ� �ִϸ��̼� �۵�
                opened = 1;         // ���̻��� �۵��� ������Ű�� ���� opened ������ 1�� ����

                port_key = 1;     // ���������� 1�� �߰��Ͽ� key ��ũ��Ʈ�� �۵���ŵ�ϴ�. ������������ �������� ������ �������� ����ϸ� �˴ϴ�.
            }
        }
    }
}
