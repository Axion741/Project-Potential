using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour {

    private Animator pAnim;
    private Animator eAnim;
    private EnemyStats enemyStats;

    public PlayerAbilities playerAbilities;
    public GameObject enemy;
    public GameObject blast;


    public static float currentHealth;
    public static float maxHealth;
    public static float currentKi;
    public static float maxKi;

    private float damage;
    private float sDamage;
    private float attackBoost = 1f;
    private float hitValue;
    private float enemyDodge;
    
    

    // Use this for initialization
    void Start()
    {
        eAnim = enemy.GetComponent<Animator>();
        pAnim = GetComponent<Animator>();
        enemyStats = GameObject.FindObjectOfType<EnemyStats>();
        GetStats();
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

    public void GetStats()
    {
        maxHealth = playerAbilities.maxHealth;
        currentHealth = maxHealth;
        maxKi = playerAbilities.maxKi;
        currentKi = maxKi;
        damage = playerAbilities.physicalDamage;
        sDamage = playerAbilities.spiritDamage;
    }

    private void HitChecker()
    {
        hitValue = Random.Range(0, 100);
        enemyDodge = EnemyStats.evasionChance;
    }

    //Combat Methods

    public void PunchAttack()
    {
        HitChecker();
        pAnim.SetTrigger("isPunching");
        //TurnController.TurnChange();
    }

    public void PunchDamage()
    {
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            EnemyStats.currentHealth = EnemyStats.currentHealth - damage * attackBoost;
            enemyStats.HealthChecker();
            eAnim.SetTrigger("isDamaged");
        }
    }

    public void KickAttack()
    {
        HitChecker();
        pAnim.SetTrigger("isKicking");
        //TurnController.TurnChange();
    }

    public void KickDamage()
    {
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            EnemyStats.currentHealth = EnemyStats.currentHealth - damage * 2.5f * attackBoost;
            enemyStats.HealthChecker();
            eAnim.SetTrigger("isDamaged");
        }
    }

    public void BlastDashAttack()
    {
        if (currentKi < 50)
        {
            Debug.Log("Ki less than 50");
        }
        else
        {
            HitChecker();
            pAnim.SetTrigger("isBlastDash");
            currentKi -= 50;
        }
    }

    public void BlastDashDamage()
    {
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            EnemyStats.currentHealth = EnemyStats.currentHealth - sDamage * 3f * attackBoost;
            enemyStats.HealthChecker();
            eAnim.SetTrigger("isDamaged");
        }
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
        HitChecker();
        if (hitValue <= enemyDodge)
        {
            eAnim.SetTrigger("isDodging");
        }
        else if (hitValue > enemyDodge)
        {
            EnemyStats.currentHealth = EnemyStats.currentHealth - sDamage * 1f * attackBoost;
            enemyStats.HealthChecker();
            eAnim.SetTrigger("isDamaged");
        }
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