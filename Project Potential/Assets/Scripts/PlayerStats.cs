using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{

    private Animator pAnim;
    private Animator eAnim;
    private EnemyStats enemyStats;
    private ResultsController resultsController;
    private SpriteRenderer frontRender;
    private SpriteRenderer backRender;

    public PlayerAbilities playerAbilities;
    public GameObject enemy;
    public GameObject blast;
    public GameObject auraFront;
    public GameObject auraBack;


    public static float currentHealth;
    public static float maxHealth;
    public static float currentKi;
    public static float maxKi;
    public static float currentPP;
    public static float maxPP;

    private float damage;
    private float sDamage;
    private float attackBoost = 1f;
    private float tMultiplier = 1;
    private float hitValue;
    private float enemyDodge;
    private int breakChance = 5;
    private float choice;
    private float min = 1;
    private float max = 100;



    // Use this for initialization
    void Start()
    {
        eAnim = enemy.GetComponent<Animator>();
        pAnim = GetComponent<Animator>();
        enemyStats = GameObject.FindObjectOfType<EnemyStats>();
        resultsController = FindObjectOfType<ResultsController>();
        GetStats();
        frontRender = auraFront.GetComponent<SpriteRenderer>();
        backRender = auraBack.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Choice = " + choice + ", BreakChance = " + breakChance);
        Debug.Log("currentPP = " + currentPP);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            pAnim.SetBool("isDead", true);
            resultsController.LoseFight();

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
        maxPP = playerAbilities.maxPP;
        currentPP = 0;
        breakChance = PlayerPrefsManager.GetBreakChance();
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
            EnemyStats.currentHealth = EnemyStats.currentHealth - damage * tMultiplier * attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyStats.HealthChecker();
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
            EnemyStats.currentHealth = EnemyStats.currentHealth - damage * 2.5f * tMultiplier * attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyStats.HealthChecker();
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
            EnemyStats.currentHealth = EnemyStats.currentHealth - sDamage * 3f * tMultiplier* attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyStats.HealthChecker();
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
            EnemyStats.currentHealth = EnemyStats.currentHealth - sDamage * 1f * tMultiplier * attackBoost;
            eAnim.SetTrigger("isDamaged");
            enemyStats.HealthChecker();
        }
    }

    public void PowerUp()
    {
        pAnim.SetTrigger("isPowerUp");
        KiBoost();
        LimitBreak();
        attackBoost = 1 + (currentPP / 10);
        //TurnController.TurnChange();
    }

    public void MeleeReset()
    {
        if (currentPP != 0)
        {
            currentPP -= 1;
        }
        else return;
    }

    public void EnergyReset()
    {
        if (currentPP >= 2)
        {
            currentPP -= 2;
        }else if (currentPP < 2)
        {
            currentPP = 0;
        }
    }

    private void TurnChanger()
    {
        TurnController.TurnChange();
    }

    private void BlockUI()
    {
        TurnController.QuickHide();
    }

    private void KiBoost()
    {
        if (currentKi != maxKi)
        {
            currentKi += 20;
        }
        else if (currentKi >= maxKi - 20)
        {
            currentKi = maxKi;
        }

    }

    private void LimitBreak()
    {
        if (currentPP != maxPP)
        {
            currentPP = currentPP + 1;
        }
        else if (currentPP == maxPP)
        {
            //Generate number between 1/100 to compare to breakChance
            choice = Random.Range(min, max);

            if (playerAbilities.breakPoint < 2)
            {
                
                if (choice <= breakChance)
                {
                    playerAbilities.breakPoint++;
                    PlayerPrefsManager.SetBreakPoint(playerAbilities.breakPoint);
                    breakChance = 5;
                    PlayerPrefsManager.SetBreakChance(breakChance);
                    playerAbilities.DeterminePP();
                    maxPP = playerAbilities.maxPP;
                    currentPP += 1;
                }
                else if (choice > breakChance)
                {
                    breakChance += 5;
                    PlayerPrefsManager.SetBreakChance(breakChance);
                }
            else{
                    breakChance = 0;
                }

            }
        }
    }

    public void Transformation0()
    {
        frontRender.color = new Color32(122, 243, 255, 255);
        backRender.color = new Color32(122, 243, 255, 255);
        tMultiplier = 1;
    }

    public void Transformation1()
    {
        frontRender.color = new Color32(178, 0, 0, 255);
        backRender.color = new Color32(178, 0, 0, 255);
        tMultiplier = 2;
    }

    public void Transformation2()
    {
        frontRender.color = new Color32(255, 255, 0, 255);
        backRender.color = new Color32(255, 255, 0, 255);
        tMultiplier = 4;
    }

}