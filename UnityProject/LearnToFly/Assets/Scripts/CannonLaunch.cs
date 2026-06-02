using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLaunch : MonoBehaviour
{

    bool hasLaunched = false;
    public GameObject penguin;
    public GameObject arrow;
    public Rigidbody2D rb;
    public PenguinStats peng;
    int launchPower;

    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(true);
        launchPower = peng.launchPower;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Angle player is facing
        float angle = rb.rotation *Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        if (!hasLaunched)
        {
            //Don't let penguin move before launch
            rb.gravityScale = 0.0f;

            if(Input.GetKey(KeyCode.Space))
            {
                launchPower = peng.launchPower;
                //Launch Penguin
                rb.AddForce(direction * launchPower, ForceMode2D.Impulse);

                //Turn off Arrow
                arrow.SetActive(false);
                hasLaunched=true;
            }
        }
        else
        {
            rb.gravityScale = peng.gravScale;
        }
    }
}
