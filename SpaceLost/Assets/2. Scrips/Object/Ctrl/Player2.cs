using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드.
    public float rotationSpeed = 360f; // 회전 속도 지정
    public float jumpSpeed; // 캐릭터 점프 힘.
    public float gravity;    // 캐릭터에게 작용하는 중력.
    public float yVelocity;
    Animator animator;

    private CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    private Vector3 MoveDir;                // 캐릭터의 움직이는 방향.

    void Start()
    {
        speed = 3.0f;
        jumpSpeed = 8.0f;
        gravity = 20.0f;

        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
            transform.forward,
            direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
        }
        // Move()를 이용해 이동, 충돌 처리, 속도 값 얻기 가능
        

        if (Input.GetButton("Jump"))
            direction.y = jumpSpeed;
        direction.y -= gravity * Time.deltaTime;

        controller.Move(direction * speed * Time.deltaTime);

        animator.SetFloat("Speed", controller.velocity.magnitude);
    }

    

}