using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LearnToFly/Rocket Stats")]
public class RocketStats : ScriptableObject
{
    [Header("Stats")]
    public int maxGas = 20;
    public int power;
    public bool doesHave;

    public void ZeroOutAll()
    {
        maxGas = 20;
        power = 1;
        doesHave = false;
    }
}
