using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundEnd : MonoBehaviour
{
    [Header("Penguin")]
    public PenguinStats peng;
    public Transform pengObj;
    public RocketController rocketCon;

    [Header("UI")]
    public TMP_Text moneyUI;
    public TMP_Text distUI;
    public TMP_Text heightUI;
    public TMP_Text gasUI;

    private void Start()
    {
        peng.roundDist = 0;
        peng.roundHeight = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Set round values
        peng.roundDist = pengObj.position.x;    //dist
        if (pengObj.position.y > peng.roundHeight)
        {
            peng.roundHeight = pengObj.position.y;      //height
        }

        //Set max values for stats
        if (pengObj.position.x > peng.maxDist)
        {
            peng.maxDist = pengObj.position.x;      //dist
        }    
        if (pengObj.position.y > peng.maxHeight)
        {
            peng.maxHeight = pengObj.position.y;      //height
        }

        //Update UI
        moneyUI.text = "Money: " + peng.money.ToString();
        int roundedDist = (int)peng.roundDist;
        distUI.text = "Dist: " + roundedDist.ToString();
        int roundedHeight = (int)peng.roundHeight;
        heightUI.text = "Height: " + roundedHeight.ToString();
        gasUI.text = "Gas: " + rocketCon.gas.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))      //If you colide with floor
        {
            peng.money += ((int)peng.roundDist + (int)peng.roundHeight);  //Add money at end of round (casted as int)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Reset Scene
        }
    }
}
