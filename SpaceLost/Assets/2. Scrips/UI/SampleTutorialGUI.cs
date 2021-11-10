using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTutorialGUI : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 40), "오브젝트 앞에서 좌클릭 : 물건 잡기");
        GUI.Label(new Rect(10, 40, 100, 80), "오브젝트 앞에서 마우스 중앙 버튼 클릭 : 물건 놓기");
    }
}
