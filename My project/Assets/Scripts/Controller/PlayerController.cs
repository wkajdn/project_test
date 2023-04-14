using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;                  //�̵��ӵ� ���� ����
    public GameObject PlayerPivot;                  //�÷��̾� �Ǻ� ����
    Camera viewCamera;                              //ī�޶� ���� ���� �������� ���� ����
    Vector3 velocity;                               //�̵� ���� ���� �� ����
    public ProjecttileController projectileController;


    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;                   //�� ��� ī�޶� �Է�
    }

    // Update is called once per frame
    void Update()
    {
        //����� 2D -> �ΰ��� 3D ��ǥ ��ȯ (���콺�� 3D �� ��� �ִ���)
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , viewCamera.transform.position.y ));
        //�ٶ� ��ġ�� ����ϱ� ���ؼ� ������Ʈ y�� ��ǥ�� ���� (�ٴ��� x,y ��)
        Vector3 targetPosition = new Vector3(mousePos.x, transform.position.y, mousePos.z);
        //�޾ƿ� �Ǻ��� ���콺�� ���� �Ѵ�.
        PlayerPivot.transform.LookAt(targetPosition, Vector3.up);
        //w,a,s,d �� ȭ��ǥ �̵� or �����ϴ� �̵��Է� ���� (Horizontal, Vertical)
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        if(Input.GetMouseButtonDown(0))
        {
            projectileController.FireProjectile();
        }
    }


    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
        //Getcomponet -> �ҽ��� �ִ� ���ӿ�����Ʈ���� <> �ȿ� �ִ� ���۳�Ʈ�� ����
        //������ �� �Ŀ� ���� �̵� ��ġ ���� MovePoisition �Լ��� ����
    }
}
