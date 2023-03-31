using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player
{
    private int hp = 100;                                           //���� Hp�� private �ϰ� ���� 100 �Է�
    private int power = 50;                                         //���� Power�� private �ϰ� ���� 50 �Է�

    public void Attack()                                            //�޼ҵ� Attack ����
    {
        Debug.Log(this.power + " �������� ������.");
    }

    public void Damage(int damage)                                  //�޼ҵ� Damage ����
    {
        this.hp -= damage;
        Debug.Log(damage + " �������� �Ծ���.");
    }
    public int GetHp()
    {
        return hp;
    }
}
public class Test_008 : MonoBehaviour
{
    public Text playerHp;                                           //Palyer Hp �����ִ� UI
    public Text player2Hp;                                          //Player2 Hp �����ִ� UI

    Player mPlayer = new Player();                                  //Palyer Ŭ���� ���� New <====
    Player mPlayer2 = new Player();                                 //Player2 Ŭ���� ���� New <====
    // Start is called before the first frame update
    void Start()
    {
        //Player mPlayer = new Player();                              //Player Ŭ���� ���� New <===
        //mPlayer.Attack();                                           //Player �޼ҵ� Attack ȣ��
        //mPlayer. Damage(30);                                        //Player �޼ҵ� Damage ȣ��
    }                                                                 

    // Update is called once per frame
    void Update()
    {
        playerHp.text =  "Palyer1 HP : " + mPlayer.GetHp().ToString();                 //Player�� Hp�� UI�� ǥ��
        player2Hp.text = "Player2 HP" + mPlayer2.GetHp().ToString();                    //Player�� Hp�� UI�� ǥ��

        if (Input.GetMouseButtonDown(0))                            //���� ���콺
        {
            mPlayer.Damage(1);                                      //Player �޼ҵ� Damage ȣ��
        }

        if (Input.GetMouseButtonDown(1))                                //������ ���콺
        {
            mPlayer2.Damage(1);                                      //Player �޼ҵ� Damage ȣ��
        }
    }
}
