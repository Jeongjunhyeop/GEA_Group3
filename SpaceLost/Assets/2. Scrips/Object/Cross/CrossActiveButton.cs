using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossActiveButton : MonoBehaviour
{
    public bool isGreen = false;
    public int Count = 0;
    public int MaxCount = 5;

    [SerializeField]
    CrossActiveButton LinkedCrossSign;

    private void Start()
    {
        isGreen = false;
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGreen)
        {
            isGreen = true;
            Count = 0;
            LinkedCrossSign.Linking();
            StartCoroutine(CrossCountCheck());
        }
    }

    public void Linking()
    {
        if (!isGreen)
        {
            isGreen = true;
            Count = 0;
            StartCoroutine(CrossCountCheck());
        }
    }

    IEnumerator CrossCountCheck()
    {
        while (Count < MaxCount)
        {
            yield return new WaitForSeconds(1f);
            Count++;
        }
        isGreen = false;
    }
}
