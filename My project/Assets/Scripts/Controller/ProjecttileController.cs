using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileController : MonoBehaviour
{
    public Vector3 lanchDirection;              //�߻� ���� ���� ����
    public GameObject Projectile;               //�߻�ü ������ ����

    public void FireProjectile()                //�߻� �Լ� ����
    {
        GameObject temp = (GameObject)Instantiate(Projectile);      //�߻�ü �������� ���� ��Ű�� temp�� �Է�
                                                                    //lnstantiate �Լ��� GameObject , �������� ���� ��Ų��.
        temp.transform.position = this.gameObject.transform.position;
        temp.GetComponent<ProjectileMove>().launchDirection = transform.forward;

        Destroy(temp, 10f);                         //�߻�ü ������� 10�� �Ŀ� �������.
        
    }
}
