using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePenguin : MonoBehaviour
{
    public GameObject player;
    public int rotateSpeed; //Set in editor

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotate Left
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(0, 0, rotateSpeed);
        }
        //Rotate right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(0, 0, -rotateSpeed);
        }
    }
}
