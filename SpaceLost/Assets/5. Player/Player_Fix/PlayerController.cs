using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    private Movement movement;

    private void Awake()
    {
        Cursor.visible = false; //마우스 커서를 보이지 않게
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서 위치 고정

        movement = GetComponent<Movement>();
    }

    void Update()
    {

        //방향키를 눌러 이동
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //이동속도 설정(앞으로 이동할때만 5, 나머지는 3)
        //옆이나 뒤로 이동 = 3
        movement.MoveSpeed = z > 0 ? 5.0f : 3.0f;
        //이동함수 호출(카메라가 보고있는 방향을 기준으로 방향키에 따라 이동
        movement.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        //회전 설정(항상 앞만 보도록 캐릭터의 회전은 카메라와 같은 회전 값을 설정)
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }

}
