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

    //Ÿ�� �±� : �� ĭ���� ����θ� ��� ������Ʈ�� ��� ����. �±׸� ���� �� Ư�� �±׸� ���� ������Ʈ�θ� ��� ����.
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
