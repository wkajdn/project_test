using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotatine : MonoBehaviour
{

    float rotSpeed = 0;                         //변수 회전 속도

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 10000;
        }

        transform.Rotate(0, this.rotSpeed * Time.deltaTime, 0);                 //transform은 

        rotSpeed *= 0.99f;
    }

}