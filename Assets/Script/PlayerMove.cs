using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�̵��ӵ� ����
    public float moveSpeed = 7f;

    // �߷� ����
    float gravity = -20f;
    //���� �ӷ� ����
    float yVelocity = 0;

    //ĳ���� ��Ʈ�ѷ� ����
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 14f; 
        }
        else
        {
            moveSpeed = 7f;
        }

        // ������� �Է��� ����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // �̵����� ����
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //ī�޶� �������� ������ ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        //ĳ���� ���� �ӵ��� �߷� ���� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;


        // �ӵ��� ���� �̵�
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }
}
