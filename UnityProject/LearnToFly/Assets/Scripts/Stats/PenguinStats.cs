using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LearnToFly/Penguin Stats")]
public class PenguinStats : ScriptableObject
{
    [Header("Money and Powerups")]
    public int money;

    [Header("Stats")]
    public int launchPower;
    public float maxDist;
    public float maxHeight;
}
