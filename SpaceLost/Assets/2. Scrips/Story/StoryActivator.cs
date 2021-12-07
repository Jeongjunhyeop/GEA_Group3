using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryActivator : MonoBehaviour
{
    public GameObject[] police;
    public GameObject[] orb;
    public GameObject[] obj;
    private void Start()
    {
        StartCoroutine("Activator");
    }

    IEnumerator Activator()
    {
        yield return new WaitForSeconds(1f);
        police[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        orb[0].SetActive(false);
        obj[0].SetActive(true);
        police[0].SetActive(false);

        yield return new WaitForSeconds(2.5f);
        police[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        orb[1].SetActive(false);
        obj[1].SetActive(true);
        police[1].SetActive(false);

        yield return new WaitForSeconds(5f);
        police[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        orb[2].SetActive(false);
        obj[2].SetActive(true);
        police[2].SetActive(false);

        yield return new WaitForSeconds(5f);
        police[3].SetActive(true);
        yield return new WaitForSeconds(1f);
        orb[3].SetActive(false);
        obj[3].SetActive(true);
        police[3].SetActive(false);

        yield return new WaitForSeconds(5f);
        police[4].SetActive(true);
        yield return new WaitForSeconds(1f);
        orb[4].SetActive(false);
        obj[4].SetActive(true);
        police[4].SetActive(false);

        yield return new WaitForSeconds(4f);
        police[5].SetActive(true);
        yield return new WaitForSeconds(1f);
        orb[5].SetActive(false);
        obj[5].SetActive(true);
        police[5].SetActive(false);

        yield return new WaitForSeconds(2f);
        police[6].SetActive(true);
        yield return new WaitForSeconds(1f);
        orb[6].SetActive(false);
        obj[6].SetActive(true);
        police[6].SetActive(false);

    }
}
