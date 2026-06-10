using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Audio;

public class Shop : MonoBehaviour
{
    /* 
     
    How to add an item to shop
        - Create UI Item
        - Create func to call
        - Add to Update UI
        - Have a cost in poenguin stats
     
     */

    [Header("Game Objects")]
    public GameObject shopUI;
    public GameObject roundUI;
    public GameObject jetpack;
    public GameObject jetpackUI;
    public GameObject feathers;
    public GameObject feathersUI;
    public GameObject glider;
    public GameObject gliderUI;

    [Header("Audio Effects")]
    public AudioSource powerupSFX;
    public AudioSource failSFX;

    [Header("Penguin")]
    public PenguinStats pengStat;
    public RocketStats rocketStat;

    [Header("Shop Items")]
    public TMP_Text launchCostUI;
    public TMP_Text gasCostUI;
    public TMP_Text moneyUI;
    public TMP_Text powerCostUI;

    void UpdateUI()
    {
        launchCostUI.text = pengStat.LaunchCost.ToString();
        moneyUI.text = pengStat.money.ToString();
        gasCostUI.text = pengStat.gasCost.ToString();
        powerCostUI.text = pengStat.powerCost.ToString();

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
        //Check if the player has bought the wings yet
        if(pengStat.hasWings)
        {
            feathers.SetActive(true);
            feathersUI.SetActive(false);
            pengStat.rb.gravityScale = pengStat.gravScale;
        }
        else
        {
            feathers.SetActive(false);
            feathersUI.SetActive(true);
            pengStat.rb.gravityScale = pengStat.gravScale;
        }
        //Check if player bought glider
        if (pengStat.hasGlider)
        {
            glider.SetActive(true);
            gliderUI.SetActive(false);
        }
        else
        {
            glider.SetActive(false);
            gliderUI.SetActive(true);
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
            powerupSFX.Play();

        }
        else { failSFX.Play(); }
    }

    public void BuyJetpack()
    {
        if (pengStat.money >= pengStat.JetPackCost && !pengStat.hasPack)
        {
            pengStat.hasPack = true;
            pengStat.money -= pengStat.JetPackCost;
            UpdateUI();
            powerupSFX.Play();
        }
        else { failSFX.Play(); }
    }

    public void Gas()
    {
        if(pengStat.money >= pengStat.gasCost)
        {
            rocketStat.maxGas += 5;
            pengStat.money -= pengStat.gasCost;
            //Calculate new cost
            double newCost = pengStat.gasCost * 2;
            pengStat.gasCost = (int)Math.Round(newCost);
            //UpdateUI
            UpdateUI();
            powerupSFX.Play();
        }
        else { failSFX.Play(); }
    }

    public void Power()
    {
        if (pengStat.money >= pengStat.powerCost)
        {
            rocketStat.power += 1;
            pengStat.money -= pengStat.powerCost;
            //Calculate new cost
            double newCost = pengStat.powerCost * 2;
            pengStat.powerCost = (int)Math.Round(newCost);
            //UpdateUI
            UpdateUI();
            powerupSFX.Play();
        }
        else { failSFX.Play(); }
    }

    public void BuyWings()
    {
        if (pengStat.money >= pengStat.wingsCost && !pengStat.hasWings)
        {
            pengStat.hasWings = true;
            pengStat.money -= pengStat.wingsCost;
            pengStat.gravScale = 0.7f;
            pengStat.rb.gravityScale = pengStat.gravScale;
            UpdateUI();
            powerupSFX.Play();
        }
        else { failSFX.Play(); }
    }

    public void Glider()
    {
        if (pengStat.money >= pengStat.gliderCost && !pengStat.hasGlider)
        {
            pengStat.hasGlider = true;
            pengStat.money -= pengStat.gliderCost;
            UpdateUI() ;
            powerupSFX.Play();
        }
        else { failSFX.Play(); }
    }

    public void ResetGame()
    {
        pengStat.ZeroOutAll();
        UpdateUI();
        powerupSFX.Play();
    }
}
