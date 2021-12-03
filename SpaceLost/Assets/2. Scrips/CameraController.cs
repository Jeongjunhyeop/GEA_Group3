using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform target; //ī�޶� �����ϴ� ���
    [SerializeField]
    private float minDistance = 1f; //ī�޶�� target�� �ּ� �Ÿ�
    [SerializeField]
    private float maxDistance = 5f; //ī�޶�� target�� �ִ� �Ÿ�
    [SerializeField]
    private float wheelSpeed = 100f; //���콺 �� ��ũ�� �ӵ�

    public float sensitiveity = 40f; //����

    //private float yMinLimit = 5f; //ī�޶� x�� ȸ�� ���� �ּ� ��
    private float yMaxLimit = 70f; //ī�޶� y�� ȸ�� ���� �ִ� ��
    private float x, y; //���콺 �̵� ���� ��
    private float distance; //ī�޶�� target�� �Ÿ�





    private void Awake()
    {
        //���� ������ target�� ī�޶��� ��ġ�� �������� distance �� �ʱ�ȭ
        distance = Vector3.Distance(transform.position, target.position);
        //���� ī�޶��� ȸ�� ���� x, ������ ����
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {
        //target�� �������� ������ ���� x
        if (target == null) return;

        //���콺�� x,y�� ������ ���� ����
        x += Input.GetAxis("Mouse X") * sensitiveity * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * sensitiveity * Time.deltaTime;
        //������Ʈ�� ��/�Ʒ�(X��) �Ѱ� ���� ����
        y = ClampAngle(y, -yMaxLimit, yMaxLimit);
        //ī�޶��� ȸ��(Rotation) ���� ����
        transform.rotation = Quaternion.Euler(y, x, 0);

        //���콺 �� ��ũ���� �̿��� target�� ī�޶��� �Ÿ� ��(distance)����
        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        //�Ÿ��� �ּ�, �ִ� �Ÿ��� �����ؼ� �� ���� ����� �ʵ��� �Ѵ�.
        distance = Mathf.Clamp(distance, minDistance, maxDistance);



    }

    private void LateUpdate()
    {
        //target�� �������� ������ ���� ���� �ʴ´�.
        if (target == null) return;


        //ī�޶��� ��ġ(Position) ���� ����
        //target�� ��ġ�� �������� distance��ŭ �������� �i�ư���
        transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;



        Vector3 lookPosition = target.position + Vector3.zero;
        RaycastHit hitInfo;
        if (Physics.Linecast(lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer("Ground")))
            transform.position = hitInfo.point;
        if (Physics.Linecast(lookPosition, transform.position, out hitInfo, 1 << LayerMask.NameToLayer("map")))
            transform.position = hitInfo.point;



    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}

