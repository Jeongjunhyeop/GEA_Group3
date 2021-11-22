using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterState state;
    CharacterAnimation animation;
    Rigidbody rigid;
    GameObject playerGrabPoint;

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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        m_timeSinceAttack += Time.deltaTime;

        move(h, v);
        jump();
        Attack();

        if (Input.GetMouseButtonDown(2) && state.isHolding)
            Drop();
    }



    void move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0, v);

        animation.Move(h, v);

        if (movement != Vector3.zero)
        {
            float angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;

            if (90.0f > angle && angle > -90.0f)
            {
                angle = angle * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, angle);
            }
        }

        transform.Translate(movement * state.moveSpeed * Time.deltaTime);
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

            // Reset timer
            m_timeSinceAttack = 0.0f;
        }
    }

    public void Hold(GameObject item)
    {
        SetGrab(item, true);
        state.isHolding = true;
        state.grabbedThing = item;
        if(item.tag == "GoldWeapon")
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
        state.isHolding = false;
        state.grabbedThing = null;
    }

    void SetGrab(GameObject item, bool isHolding)
    {
        Collider[] itemColliders = item.GetComponents<Collider>();
        Rigidbody itemRigid = item.GetComponent<Rigidbody>();

        foreach (Collider itemCollider in itemColliders)
        {
            itemCollider.enabled = !isHolding;
        }
        itemRigid.isKinematic = isHolding;
    }
}
