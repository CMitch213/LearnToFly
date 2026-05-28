using System.Collections;
using System.Collections.Generic;
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

    [Header("UpgradeCost")]
    public int LaunchCost = 10;
    public int JetPackCost = 500;
    public bool hasPack = false;

    public void ZeroOutAll()
    {
        money = 0;
        launchPower = 8;
        maxDist = 0;
        roundDist = 0;
        maxHeight = 0;
        roundHeight = 0;

        LaunchCost = 10;
        JetPackCost = 500;
        hasPack = false;
    }
}
