using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject shopUI;
    public GameObject roundUI;
    public GameObject jetpack;
    public GameObject jetpackUI;

    [Header("Penguin")]
    public PenguinStats pengStat;

    [Header("Shop Items")]
    public TMP_Text launchCostUI;
    public TMP_Text moneyUI;

    void UpdateUI()
    {
        launchCostUI.text = pengStat.LaunchCost.ToString();
        moneyUI.text = pengStat.money.ToString();

        //See if player has jetpack, if so load image
        if (pengStat.hasPack)
        {
            jetpack.SetActive(true);
            jetpackUI.SetActive(false);
        }
        else 
        { 
            jetpack.SetActive(false); 
            jetpackUI.SetActive(true);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void Launch()
    {
        roundUI.SetActive(true);
        shopUI.SetActive(false);
    }

    public void LaunchPower()
    {
        if (pengStat.money >= pengStat.LaunchCost)
        {
            pengStat.launchPower += 5;
            pengStat.money -= pengStat.LaunchCost;
            //Calculate new cost
            double newCost = pengStat.LaunchCost * 2;
            pengStat.LaunchCost = (int)Math.Round(newCost);
            //UpdateUI
            UpdateUI();

        }
    }

    public void BuyJetpack()
    {
        if (pengStat.money >= pengStat.JetPackCost && !pengStat.hasPack)
        {
            pengStat.hasPack = true;
            pengStat.money -= pengStat.JetPackCost;
            UpdateUI();
        }
    }

    public void ResetGame()
    {
        pengStat.ZeroOutAll();
        UpdateUI();
    }
}
