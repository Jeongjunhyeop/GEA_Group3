using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerStatue state;

    float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<PlayerStatue>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        move(h, v);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void move(float h, float v)
    {
        Vector3 movement = new Vector3(h, 0, v);

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
}
