using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_004 : MonoBehaviour
{
        public int hp = 180;
        public Text textUI;
        public Text hpTextUI;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hp += 10;
        }
        if (Input.GetMouseButtonDown(1))
        {
            hp -= 10;
        }
       
        if (hp <= 50)
        {
            textUI.text = "도망 !";
        }
        else if (hp >= 200)
        {
            textUI.text = "공격 !";
        }
        else
        {
            textUI.text = "방어 !";
    }
        hpTextUI.text = "HP : " + hp.ToString();
    }
}
