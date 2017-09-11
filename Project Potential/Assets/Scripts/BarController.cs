using System.Collections;
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
}
