using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : MonoBehaviour
{
    int dir;

    public float speed;
    public int rotation;


    public bool isChange;

    void Start()
    {
        dir = 1;
        isChange = true;
        speed *= 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x+speed*dir, transform.position.y, transform.position.z);

        if (isChange)
            StartCoroutine("ChangeDir");
        if (gameObject.name == "BigShip")
        {
            switch (dir)
            {
                case -1://왼쪽으로 가면
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;

                case 1: //오른쪽으로 가면
                    transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y + rotation, 0));
                    break;
            }
        }
        else
        {
            switch (dir)
            {
                case -1://왼쪽으로 가면
                    transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y - rotation, 0));
                    break;

                case 1: //오른쪽으로 가면
                    transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y + rotation, 0));
                    break;
            }
        }
    }

    IEnumerator ChangeDir()
    {
        isChange = false;
        yield return new WaitForSecondsRealtime(30f);
        dir *= -1;
        isChange = true;

    }
}
