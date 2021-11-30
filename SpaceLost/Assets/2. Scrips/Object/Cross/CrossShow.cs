using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossShow : MonoBehaviour
{
    [SerializeField]
    CrossActiveButton CrossActiveButton;

    public GameObject GreenLight;
    public GameObject RedLight;
    public GameObject[] Numbers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CrossActiveButton.isGreen)
        {
            GreenLight.SetActive(true);
            RedLight.SetActive(false);
            Numbers[CrossActiveButton.MaxCount - CrossActiveButton.Count - 1].SetActive(true);
            if (CrossActiveButton.Count != 0)
            {
                Numbers[CrossActiveButton.MaxCount - CrossActiveButton.Count].SetActive(false);
            }
        }
        else
        {
            GreenLight.SetActive(false);
            RedLight.SetActive(true);
            NumberOff();
        }
    }

    void NumberOff()
    {
        foreach (GameObject num in Numbers)
        {
            num.SetActive(false);
        }
    }
}
