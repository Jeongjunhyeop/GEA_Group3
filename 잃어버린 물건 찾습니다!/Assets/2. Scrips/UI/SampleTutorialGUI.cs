using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTutorialGUI : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 40), "������Ʈ �տ��� ��Ŭ�� : ���� ���");
        GUI.Label(new Rect(10, 40, 100, 80), "������Ʈ �տ��� ���콺 �߾� ��ư Ŭ�� : ���� ����");
    }
}
