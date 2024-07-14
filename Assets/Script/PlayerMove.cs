using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //이동속도 변수
    public float moveSpeed = 7f;

    // 중력 변수
    float gravity = -20f;
    //수직 속력 변수
    float yVelocity = 0;

    //캐릭터 컨트롤러 변수
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

        // 사용자의 입력을 받음
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        //카메라를 기준으로 방향을 변환
        dir = Camera.main.transform.TransformDirection(dir);

        //캐릭터 수직 속도에 중력 값을 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;


        // 속도에 맞춰 이동
        cc.Move(dir * moveSpeed * Time.deltaTime);

    }
}
