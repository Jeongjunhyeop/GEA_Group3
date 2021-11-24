using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform target;       //ī�޶� �����ϴ� ���
    [SerializeField]
    private Transform cameraArm;    //ī�޶�
    [SerializeField]
    private float minDistance = 1f; //ī�޶�� target�� �ּ� �Ÿ�
    [SerializeField]
    private float maxDistance = 5f; //ī�޶�� target�� �ִ� �Ÿ�
    [SerializeField]
    private float wheelSpeed = 100f; //���콺 �� ��ũ�� �ӵ�

    public float sensitiveity = 100f; //����

    //private float yMinLimit = 5f; //ī�޶� x�� ȸ�� ���� �ּ� ��
    private float yMaxLimit = 70f; //ī�޶� y�� ȸ�� ���� �ִ� ��
    private float x, y; //���콺 �̵� ���� ��
    private float distance; //ī�޶�� target�� �Ÿ�

    private CharacterState PlayerState;
    private CharacterAnimation animation;
    private Rigidbody rigid;

    private void Awake()
    {
        //���� ������ target�� ī�޶��� ��ġ�� �������� distance �� �ʱ�ȭ
        distance = Vector3.Distance(cameraArm.transform.position, target.position);
        //���� ī�޶��� ȸ�� ���� x, ������ ����
        Vector3 angles = cameraArm.transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void Start()
    {
        PlayerState = target.GetComponent<CharacterState>();
        animation = target.GetComponent<CharacterAnimation>();
        rigid = GetComponent<Rigidbody>();
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
        cameraArm.transform.rotation = Quaternion.Euler(y, x, 0);

        //���콺 �� ��ũ���� �̿��� target�� ī�޶��� �Ÿ� ��(distance)����
        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        //�Ÿ��� �ּ�, �ִ� �Ÿ��� �����ؼ� �� ���� ����� �ʵ��� �Ѵ�.
        distance = Mathf.Clamp(distance, minDistance, maxDistance);


        Move();
        jump();
    }

    private void LateUpdate()
    {
        //target�� �������� ������ ���� ���� �ʴ´�.
        if (target == null) return;


        //ī�޶��� ��ġ(Position) ���� ����
        //target�� ��ġ�� �������� distance��ŭ �������� �i�ư���
        cameraArm.transform.position = cameraArm.transform.rotation * new Vector3(0, 0, -distance) + target.position;

        Vector3 lookPosition = target.position + Vector3.zero;
        RaycastHit hitInfo;
        if (Physics.Linecast(lookPosition, cameraArm.transform.position, out hitInfo, 1 << LayerMask.NameToLayer("Ground")))
            cameraArm.transform.position = hitInfo.point;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }

    private void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = movement.magnitude != 0;
        animation.Move(isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.transform.forward.x, 0f, cameraArm.transform.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.transform.right.x, 0f, cameraArm.transform.right.z).normalized;
            Vector3 moveDir = lookForward * movement.y + lookRight * movement.x;

            transform.forward = moveDir;
            //transform.Translate(moveDir * Time.deltaTime * PlayerState.moveSpeed);
            transform.position += moveDir * Time.deltaTime * PlayerState.moveSpeed;
        }
    }

    void jump()
    {
        if (!PlayerState.onGround)
            return;

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerState.onGround = false;
            rigid.AddForce(Vector3.up * PlayerState.jumpPower, ForceMode.Impulse);
            animation.Jump();
        }
    }
}
