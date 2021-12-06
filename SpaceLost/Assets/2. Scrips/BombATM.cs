using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombATM : MonoBehaviour
{
    public int missionObj;
    public bool objAllCheck;
    [Header("프리팹")]
    public GameObject[] dropItemPrefab; //아이템 프리팹저장
    // Start is called before the first frame update
    void Start()
    {
        missionObj = 0;
        objAllCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(missionObj ==3 && objAllCheck == false)
        {
            GameObject dropItem = dropItemPrefab[0];
            Instantiate(dropItem, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
            Invoke("objtrue", 0.01f);
        }

        //else
        //{
        //    objAllCheck = false;
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MissionObj")
        {
            missionObj += 1;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "MissionObj")
        {
            missionObj -= 1;
        }
    }

    public void objtrue()
    {
        objAllCheck = true;
    }
}
