using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LearnToFly/Rocket Stats")]
public class RocketStats : ScriptableObject
{
    [Header("Stats")]
    public int maxGas;
    public int power;
    public bool doesHave;
}
