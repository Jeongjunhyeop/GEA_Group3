using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    GameObject player;
    GameObject playerGrabPoint;
    PlayerMove playerMove;

    bool isPlayerEnter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerGrabPoint = GameObject.FindGameObjectWithTag("GrabPoint");
        playerMove = player.GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            isPlayerEnter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            isPlayerEnter = false;
    }

    private void Update()
    {
        grab();
    }

    void grab()
    {
        if (Input.GetMouseButtonDown(0) && isPlayerEnter)
        {
            transform.SetParent(playerGrabPoint.transform);
            transform.localPosition = Vector3.zero;
            transform.rotation = new Quaternion(90, 90, 0, 0);

            playerMove.Hold(gameObject);
            isPlayerEnter = false;
        }
    }
}
