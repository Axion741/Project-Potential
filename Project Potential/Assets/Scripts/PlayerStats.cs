using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour {

    private Animator pAnim;
    private Animator eAnim;

    public GameObject enemy;

    public static float currentHealth;
    public static float maxHealth = 100;
    public static float currentKi;
    public static float maxKi = 100;

    private float damage = 10;
    private float attackBoost = 1f;
    
    

    // Use this for initialization
    void Start()
    {
        eAnim = enemy.GetComponent<Animator>();
        pAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentKi = maxKi;
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Player Health = " + currentHealth);
        print("attackboost = " + attackBoost);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            pAnim.SetBool("isDead", true);
        }
    }

    public void PunchAttack()
    {
        pAnim.SetTrigger("isPunching");
        //TurnController.TurnChange();
    }

    public void PunchDamage()
    {
        EnemyStats.currentHealth = EnemyStats.currentHealth - damage * attackBoost;
        eAnim.SetTrigger("isDamaged");
    }

    public void KickAttack()
    {
        pAnim.SetTrigger("isKicking");
        //TurnController.TurnChange();
    }

    public void KickDamage()
    {
        EnemyStats.currentHealth = EnemyStats.currentHealth - damage * 2.5f * attackBoost;
        eAnim.SetTrigger("isDamaged");
    }

    public void BlastDashAttack()
    {
        if (currentKi < 50)
        {
            Debug.Log("Ki less than 50");
        }
        else
        {
            pAnim.SetTrigger("isBlastDash");
            currentKi -= 50;
        }
    }

    public void BlastDashDamage()
    {
        EnemyStats.currentHealth = EnemyStats.currentHealth - damage * 4f * attackBoost;
        eAnim.SetTrigger("isDamaged");
    }

    public void PowerUp()
    {
        pAnim.SetTrigger("isPowerUp");
        currentKi += 20;
        attackBoost = attackBoost + 0.1f;
        //TurnController.TurnChange();
    }

    public void BoostReset()
    {
        attackBoost = 1;
    }

    private void TurnChanger()
    {
        TurnController.TurnChange();
    }
}