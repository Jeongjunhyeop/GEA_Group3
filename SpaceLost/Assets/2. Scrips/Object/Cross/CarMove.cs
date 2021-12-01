using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float moveSpeed = 35f;
    public string LinkedCross = "CrossButton";
    public Direct direct;
    CrossActiveButton cross;
    Rigidbody rigid;

    public enum Direct
    {
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    // Start is called before the first frame update
    void Start()
    {
        cross = GameObject.FindGameObjectWithTag(LinkedCross).GetComponent<CrossActiveButton>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cross.isGreen)
            return;

        switch (direct)
        {
            case Direct.UP:
                rigid.position += Vector3.forward * moveSpeed * Time.deltaTime;
                break;
            case Direct.DOWN:
                rigid.position += Vector3.back * moveSpeed * Time.deltaTime;
                break;
            case Direct.LEFT:
                rigid.position += Vector3.left * moveSpeed * Time.deltaTime;
                break;
            case Direct.RIGHT:
                rigid.position += Vector3.right * moveSpeed * Time.deltaTime;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CarEnd")
            Destroy(this.gameObject);
    }
}
