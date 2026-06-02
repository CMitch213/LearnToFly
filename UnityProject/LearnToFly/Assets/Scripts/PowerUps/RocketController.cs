using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject img;
    public RocketStats stats;
    public Rigidbody2D rb;
    public int gas;
    public PenguinStats penguin;
    public TMP_Text ui;
    //public GameObject peng;

    // Start is called before the first frame update
    void Start()
    {
        gas = stats.maxGas;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ui.text = gas.ToString();
        //Angle player is facing
        float angle = rb.rotation * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        if (Input.GetKey(KeyCode.Space) && gas > 0 && penguin.hasPack)
        {
            //Launch Penguin
            rb.AddForce(direction * stats.power, ForceMode2D.Impulse);
            gas--;

        }
    }
}
