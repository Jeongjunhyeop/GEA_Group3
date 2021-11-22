using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public enum ItemDestoryKind
    {
        DontDestroy,
        Destroy,
    }
    public enum ItemKind
    {
        TimeUp, //�����÷��̽ð� ����
        SpeedUp, //�÷��̾� �̵��ӵ� �Ͻ� ����
        SpeedDown, //�� �̵��ӵ� �Ͻ� ����
        Empty, //��
        Nav, //�̼Ǿ����� ��ġ ǥ��
        Sheild, //���� 1ȸ ����
    };
    public ItemKind kind;
    public ItemDestoryKind desKind;
    [SerializeField]
    private float rotateSpeed; //������ ȸ���ӵ�

    private void Start(){
        if (desKind == ItemDestoryKind.Destroy)
        {
            StartCoroutine("ItemDestroy");
            if (kind == ItemKind.Empty)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (kind == ItemKind.Empty)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update(){
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //������ ȸ��
    }


    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            CharacterState aStatus = other.GetComponent<CharacterState>();
            aStatus.GetItem(kind);
            Destroy(gameObject); //�����ۻ���
        }
    }

    IEnumerator ItemDestroy()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(gameObject);
    }
}
