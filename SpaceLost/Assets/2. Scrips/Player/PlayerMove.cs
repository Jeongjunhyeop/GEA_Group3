using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterState state;
    CharacterAnimation animation;
    Rigidbody rigid;
    GameObject playerGrabPoint;
    [SerializeField]
    Transform camera;
    float rotationSpeed = 5f;

    private float m_timeSinceAttack = 0.0f;
    public float m_attackableTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //마우스 커서를 보이지 않게
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서 위치 고정

        state = GetComponent<CharacterState>();
        animation = GetComponent<CharacterAnimation>();
        rigid = GetComponent<Rigidbody>();
        playerGrabPoint = GameObject.FindGameObjectWithTag("GrabPoint");
    }

    void FixedUpdate()
    {
        m_timeSinceAttack += Time.deltaTime;
        if (state.isGrogging)
            return;

        Move();
        jump();
        Attack();

        if (Input.GetMouseButtonDown(2) && state.isHolding)
            Drop();
    }



    private void Move()
    {
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = movement.magnitude != 0;
        animation.Move(isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(camera.transform.forward.x, 0f, camera.transform.forward.z).normalized;
            Vector3 lookRight = new Vector3(camera.transform.right.x, 0f, camera.transform.right.z).normalized;
            Vector3 moveDir = lookForward * movement.y + lookRight * movement.x;

            transform.forward = moveDir;
            //transform.Translate(moveDir * Time.deltaTime * PlayerState.moveSpeed);
            transform.position += moveDir * Time.deltaTime * state.moveSpeed;
        }
    }

    void jump()
    {
        if (!state.onGround)
            return;

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            state.onGround = false;
            rigid.AddForce(Vector3.up * state.jumpPower, ForceMode.Impulse);
            animation.Jump();
        }
    }

    void Attack()
    {
        if (state.isHolding && Input.GetMouseButtonDown(1) && m_timeSinceAttack > m_attackableTime)
        {
            animation.Attack();
            GameObject.Find("SoundController").GetComponent<SoundControl>().Punch();
            // Reset timer
            m_timeSinceAttack = 0.0f;
        }
    }

    public void Hold(GameObject item)
    {
        SetGrab(item, true);
        state.isHolding = true;
        state.grabbedThing = item;
        if (item.tag == "GoldWeapon")
        {
            state.powerBoost = true;
        }
        else
        {
            state.powerBoost = false;
        }
    }

    void Drop()
    {
        GameObject item = playerGrabPoint.GetComponentInChildren<Rigidbody>().gameObject;
        SetGrab(item, false);

        playerGrabPoint.transform.DetachChildren();
        if (item.tag == "MissionObj" || item.tag == "MissionBox")
        {
            item.SendMessage("MinimapOn");
        }
        state.isHolding = false;
        state.grabbedThing = null;
    }

    void SetGrab(GameObject item, bool isHolding)
    {
        Collider[] itemColliders = item.GetComponents<Collider>();
        Rigidbody itemRigid = item.GetComponent<Rigidbody>();
        UnityEngine.AI.NavMeshObstacle navMeshObstacle = item.GetComponent<UnityEngine.AI.NavMeshObstacle>();
        foreach (Collider itemCollider in itemColliders)
        {
            itemCollider.enabled = !isHolding;
        }
        itemRigid.isKinematic = isHolding;
        if(navMeshObstacle != null)
        {
            navMeshObstacle.enabled = !isHolding;
        }
        
    }

    IEnumerator PunchSound()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("SoundController").GetComponent<SoundControl>().Punch();
    }
}
