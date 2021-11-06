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

    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<CharacterState>();
        animation = GetComponent<CharacterAnimation>();
        rigid = GetComponent<Rigidbody>();
        playerGrabPoint = GameObject.FindGameObjectWithTag("GrabPoint");
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        move(h, v);
        jump();

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

    public void Hold(GameObject item)
    {
        SetGrab(item, true);
        state.isHolding = true;
    }

    void Drop()
    {
        GameObject item = playerGrabPoint.GetComponentInChildren<Rigidbody>().gameObject;
        SetGrab(item, false);

        playerGrabPoint.transform.DetachChildren();
        state.isHolding = false;
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
