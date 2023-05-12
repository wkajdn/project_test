using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyControllor : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 1.0f;

    public GameObject bulletPrefab;
    public GameObject enemyPiovt;

    public Transform firePoint;
    public float fireRate = 1.0f;
    public float nextFireTime;

    private Rigidbody rb;                   //Rigidbody선언
    private Transform player;               //플레이어 위치 가져오기 위해 선언

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                     //시작할 떄 자기 자신의 Rigidbody를 받아 온다.
        player = GameObject.FindGameObjectWithTag("Player").transform;          //Scenes에서 Player Tag를 가진 오브젝트를 가져와서 Transform을 참조
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (Vector3.Distance(player.position, transform.position) > 1.0f)           //Vector3.Distance <== 거리를 알려주는 함수
            {
                Vector3 direction = (player.position - transform.position).normalized;           //두 벡터를 빼고 Normlized하면 방향 값을 알려줌
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);      //플레이어를 향해서 설정한 speed 속도로 이동
            }

            Vector3 targetDirection = (player.position - enemyPiovt.transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            enemyPiovt.transform.rotation = Quaternion.Lerp(enemyPiovt.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + 1.0f / fireRate;
                GameObject temp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                temp.GetComponent<ProjectileMove>().launchDirection = firePoint.localRotation * -Vector3.forward;
                temp.GetComponent<ProjectileMove>().bulletType = ProjectileMove.BULLETTYPE.ENEMY;
            }
        }
      
    }
}
