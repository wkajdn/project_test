using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyControllor : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody rb;                   //Rigidbody����
    private Transform player;               //�÷��̾� ��ġ �������� ���� ����

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                     //������ �� �ڱ� �ڽ��� Rigidbody�� �޾� �´�.
        player = GameObject.FindGameObjectWithTag("Player").transform;          //Scenes���� Player Tag�� ���� ������Ʈ�� �����ͼ� Transform�� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position , transform.position) > 1.0f)           //Vector3.Distance <== �Ÿ��� �˷��ִ� �Լ�
        {
            Vector3 direction = (player.position - transform.position).normalized;           //�� ���͸� ���� Normlized�ϸ� ���� ���� �˷���
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);      //�÷��̾ ���ؼ� ������ speed �ӵ��� �̵�
        }
    }
}
