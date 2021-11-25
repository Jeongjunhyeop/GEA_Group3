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
        Cursor.visible = false; //���콺 Ŀ���� ������ �ʰ�
        Cursor.lockState = CursorLockMode.Locked; //���콺 Ŀ�� ��ġ ����

        movement = GetComponent<Movement>();
    }

    void Update()
    {

        //����Ű�� ���� �̵�
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //�̵��ӵ� ����(������ �̵��Ҷ��� 5, �������� 3)
        //���̳� �ڷ� �̵� = 3
        movement.MoveSpeed = z > 0 ? 5.0f : 3.0f;
        //�̵��Լ� ȣ��(ī�޶� �����ִ� ������ �������� ����Ű�� ���� �̵�
        movement.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        //ȸ�� ����(�׻� �ո� ������ ĳ������ ȸ���� ī�޶�� ���� ȸ�� ���� ����)
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }

}
