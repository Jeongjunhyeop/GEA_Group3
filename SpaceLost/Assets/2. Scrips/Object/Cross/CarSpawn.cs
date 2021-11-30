using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public float spawnLength = 3f;
    public float spawnAfter = 0f;
    public string LinkedCross = "CrossButton";
    [SerializeField]
    GameObject CarPrefab;
    CrossActiveButton cross;

    // Start is called before the first frame update
    void Start()
    {
        cross = GameObject.FindGameObjectWithTag(LinkedCross).GetComponent<CrossActiveButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cross.isGreen)
            return;

        spawnAfter += 0.1f;
        if (spawnAfter > spawnLength)
        {
            Instantiate(CarPrefab);
            spawnAfter = 0f;
        }
    }
}
