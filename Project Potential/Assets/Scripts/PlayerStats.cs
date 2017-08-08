using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour {

    private Animator pAnim;
    private Animator eAnim;

    public PlayerAbilities playerAbilities;
    public GameObject enemy;
    public GameObject blast;


    public static float currentHealth;
    public static float maxHealth;
    public static float currentKi;
    public static float maxKi;

    private float damage = 10;
    private float attackBoost = 1f;
    
    

    // Use this for initialization
    void Start()
    {
        eAnim = enemy.GetComponent<Animator>();
        pAnim = GetComponent<Animator>();
        GetMaxHealth();
        GetMaxKi();
        print(maxHealth);
        print(maxKi);        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("currentHealth = " + currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            pAnim.SetBool("isDead", true);
        }
    }

    //Stat Control

        public void GetMaxHealth()
    {
        maxHealth = playerAbilities.maxHealth;
        currentHealth = maxHealth;
    }

        public void GetMaxKi()
    {
        maxKi = playerAbilities.maxKi;
        currentKi = maxKi;
    }
    
    //Combat Methods

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

    public void BlastBarrageAttack()
    {
        if (currentKi < 40)
        {
            Debug.Log("Ki less than 40");
        }
        else
        {
            pAnim.SetTrigger("isBarrage");
        }
    }

    public void SpawnBlast()
    {
        GameObject playerBlast = Instantiate(blast, new Vector3(2.841f, 3.857f, -1), Quaternion.identity);
        playerBlast.GetComponent<Rigidbody2D>().velocity = new Vector3(8, 0, 0);
        currentKi -= 20;
    }

    public void BlastBarrageDamage()
    {
        EnemyStats.currentHealth = EnemyStats.currentHealth - damage * 1.5f * attackBoost;
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

    private void BlockUI()
    {
        TurnController.QuickHide();
    }
}