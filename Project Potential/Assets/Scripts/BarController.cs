using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour {
    
    private float fillValue;

    [SerializeField]
    private Image playerHealthBar;

    [SerializeField]
    private Image playerKiBar;

    [SerializeField]
    private Image enemyHealthBar;

    [SerializeField]
    private Image enemyKiBar;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerHealthBar();
        PlayerKiBar();
        EnemyKiBar();
        EnemyHealthBar();
	}

    private void PlayerHealthBar()
    {
        fillValue = PlayerStats.currentHealth /PlayerStats.maxHealth;
        playerHealthBar.fillAmount = fillValue;
    }

    private void PlayerKiBar()
    {
        fillValue = PlayerStats.currentKi / PlayerStats.maxKi;
        playerKiBar.fillAmount = fillValue;
    }

    private void EnemyHealthBar()
    {
        fillValue = EnemyStats.currentHealth / EnemyStats.maxHealth;
        enemyHealthBar.fillAmount = fillValue;
    }

    private void EnemyKiBar()
    {
        fillValue = EnemyStats.currentKi / EnemyStats.maxKi;
        enemyKiBar.fillAmount = fillValue;
    }
}
