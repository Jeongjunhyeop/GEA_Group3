using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTogle : MonoBehaviour
{
    public bool isGreen = false;

    public TYPE Type = TYPE.TOGGLE;

    public enum TYPE
    {
        TOGGLE,
        PRESS,
    }

    //타겟 태그 : 빈 칸으로 비워두면 모든 오브젝트로 토글 가능. 태그를 넣을 시 특정 태그를 가진 오브젝트로만 토글 가능.
    public string TargetTag = "";

    public Door[] LinkedDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (Type == TYPE.PRESS)
            return;

        if (TargetTag != "")
        {
            if (other.tag != TargetTag)
                return;
        }
        Debug.Log(other.name);
        isGreen = !isGreen;

        if (isGreen)
            foreach (Door door in LinkedDoor)
                door.ButtonSign(1);
        else
            foreach (Door door in LinkedDoor)
                door.ButtonSign(-1);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Type == TYPE.TOGGLE)
            return;

        bool prebState = isGreen;

        if (TargetTag != "")
        {
            if (other.tag != TargetTag)
                return;
        }

        isGreen = true;

        if (prebState != isGreen)
            foreach (Door door in LinkedDoor)
                door.ButtonSign(1);
    }

    private void OnTriggerExit(Collider other)
    {
        if (Type == TYPE.TOGGLE)
            return;

        bool prebState = isGreen;

        if (TargetTag != "")
        {
            if (other.tag != TargetTag)
                return;
        }

        isGreen = false;

        if (prebState != isGreen)
            foreach (Door door in LinkedDoor)
                door.ButtonSign(-1);
    }
}
