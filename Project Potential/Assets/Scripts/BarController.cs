﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour {
    
    private float fillValue;
    private float barSpeed = 4;

    [SerializeField]
    private Image playerHealthBar;

    [SerializeField]
    private Image playerKiBar;

    [SerializeField]
    private Image enemyHealthBar;

    [SerializeField]
    private Image enemyKiBar;

    [SerializeField]
    private Image powerBar1;

    [SerializeField]
    private Image powerBar2;

    [SerializeField]
    private Image powerBar3;

    public GameObject powerBarLevel1;
    public GameObject powerBarLevel2;
    public GameObject powerBarLevel3;

    private int breakPoint;
    private PlayerAbilities playerAbilities;
    private PlayerStats playerStats;


    // Use this for initialization
    void Start () {
        playerAbilities = FindObjectOfType<PlayerAbilities>();
        playerStats = FindObjectOfType<PlayerStats>();
        breakPoint = playerAbilities.breakPoint;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerHealthBar();
        PlayerKiBar();
        EnemyKiBar();
        EnemyHealthBar();
        PowerBarController();
        breakPoint = playerAbilities.breakPoint;
    }

    private void PlayerHealthBar()
    {
        fillValue = PlayerStats.currentHealth /PlayerStats.maxHealth;
        playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount, fillValue, Time.deltaTime*barSpeed);
    }

    private void PlayerKiBar()
    {
        fillValue = PlayerStats.currentKi / PlayerStats.maxKi;
        playerKiBar.fillAmount = Mathf.Lerp(playerKiBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void EnemyHealthBar()
    {
        fillValue = EnemyStats.currentHealth / EnemyStats.maxHealth;
        enemyHealthBar.fillAmount = Mathf.Lerp(enemyHealthBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void EnemyKiBar()
    {
        fillValue = EnemyStats.currentKi / EnemyStats.maxKi;
        enemyKiBar.fillAmount = Mathf.Lerp(enemyKiBar.fillAmount, fillValue, Time.deltaTime * barSpeed);
    }

    private void PowerBarController()
    {
        if (breakPoint == 0)
        {
            powerBarLevel1.SetActive(true);
            powerBarLevel2.SetActive(false);
            powerBarLevel3.SetActive(false);
            PowerBar1();
        }
        else if (breakPoint == 1)
        {
            powerBarLevel1.SetActive(false);
            powerBarLevel2.SetActive(true);
            powerBarLevel3.SetActive(false);
            PowerBar2();
        }
        else if (breakPoint == 2)
        {
            powerBarLevel1.SetActive(false);
            powerBarLevel2.SetActive(false);
            powerBarLevel3.SetActive(true);
            PowerBar3();
        }
    }

    private void PowerBar1()
    {
        fillValue = PlayerStats.currentPP / PlayerStats.maxPP;
        powerBar1.fillAmount = Mathf.Lerp(powerBar1.fillAmount, fillValue, Time.deltaTime * barSpeed);
        playerStats.Transformation0();
    }

    private void PowerBar2()
    {
        fillValue = PlayerStats.currentPP / PlayerStats.maxPP;
        powerBar2.fillAmount = Mathf.Lerp(powerBar2.fillAmount, fillValue, Time.deltaTime * barSpeed);
        if (fillValue <= 0.5)
        {
            powerBar2.color = new Color32(122, 243, 255, 255);
            playerStats.Transformation0();
        }
        else if (fillValue > 0.5)
        {
            powerBar2.color = new Color32(178, 0, 0, 255);
            playerStats.Transformation1();
        }
    }

    private void PowerBar3()
    {
        fillValue = PlayerStats.currentPP / PlayerStats.maxPP;
        powerBar3.fillAmount = Mathf.Lerp(powerBar3.fillAmount, fillValue, Time.deltaTime * barSpeed);
        if (fillValue <= 0.33333333)
        {
            powerBar3.color = new Color32(122, 243, 255, 255);
            playerStats.Transformation0();
        }
        else if (fillValue > 0.34 && fillValue <= 0.666666)
        {
            powerBar3.color = new Color32(178, 0, 0, 255);
            playerStats.Transformation1();
        }
        else if (fillValue > 0.67)
        {
            powerBar3.color = new Color32(255, 255, 0, 255);
            playerStats.Transformation2();
        }
    }
}
