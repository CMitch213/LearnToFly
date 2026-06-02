using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "LearnToFly/Penguin Stats")]
public class PenguinStats : ScriptableObject
{
    [Header("Money and Powerups")]
    [ContextMenuItem("Reset all Stats", "ZeroOutAll")]      //Right Click context menu to reset stats
    public int money;

    [Header("Stats")]
    public int launchPower;
    public float roundDist;
    public float maxDist;
    public float roundHeight;
    public float maxHeight;
    public RocketStats rocketStats;
    public Rigidbody2D rb;
    public GameObject penguin;
    public float gravScale = 1;

    [Header("UpgradeCost")]
    public int LaunchCost = 10;
    public int JetPackCost = 500;
    public bool hasPack = false;
    public int gasCost = 30;
    public int powerCost = 1000;
    public int wingsCost = 400;
    public bool hasWings = false;

    void Start()
    {
        
    }

    public void ZeroOutAll()
    {
        money = 0;
        launchPower = 8;
        maxDist = 0;
        roundDist = 0;
        maxHeight = 0;
        roundHeight = 0;

        LaunchCost = 10;
        gasCost = 30;
        JetPackCost = 500;
        powerCost = 1000;
        hasPack = false;
        wingsCost = 400;
        hasWings = false;
        rb.gravityScale = gravScale;
        gravScale = 1;
        rocketStats.ZeroOutAll();
    }
}
