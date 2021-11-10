using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{

    public enum ItemKind
    {
        TimeUp, //�����÷��̽ð� ����
        SpeedUp, //�÷��̾� �̵��ӵ� �Ͻ� ����
        SpeedDown, //�� �̵��ӵ� �Ͻ� ����
        Empty, //��
        Nav, //�̼Ǿ����� ��ġ ǥ��
        Sheild, //���� 1ȸ ����
        MissionObject, //�̼Ǿ�����
    };
    public ItemKind kind;
    [SerializeField]
    private float rotateSpeed; //������ ȸ���ӵ�

    private void Start(){
        if(kind == ItemKind.Empty){
            Destroy(gameObject);
        }
    }

    void Update(){
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World); //������ ȸ��
        StartCoroutine("DestroyItem");
    }

    IEnumerator DestroyItem(){
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            CharacterState aStatus = other.GetComponent<CharacterState>();
            aStatus.GetItem(kind);
            Destroy(gameObject); //�����ۻ���
        }
    }
}