using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    private Animator eAnim;
    private Animator pAnim;
    public GameObject player;
    public GameObject blast;
    private GameObject pBlast;
    int max = 100;
    int min = 1;
    int choice;

    public static float currentHealth;
    public static float maxHealth = 100;
    public static float currentKi;
    public static float maxKi = 100;
    private float damage = 10;
    private float attackBoost = 1f;


    // Use this for initialization
    void Start () {
        pAnim = player.GetComponent<Animator>();
        eAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentKi = maxKi;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            eAnim.SetBool("isDead", true);
        }

	}

    private void PunchAttack()
    {
        eAnim.SetTrigger("isPunching");
        //TurnController.TurnChange();
    }

    public void PunchDamage()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - damage * attackBoost;
        pAnim.SetTrigger("isDamaged");
    }

    private void KickAttack()
    {
        eAnim.SetTrigger("isKicking");
        //TurnController.TurnChange();
    }

    public void KickDamage()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - damage * 2.5f * attackBoost;
        pAnim.SetTrigger("isDamaged");
    }

    public void BlastDashAttack()
    {
        if (currentKi < 50)
        {
            Debug.Log("Too little Ki");
            EnemyAI();
        }
        else
        {
            eAnim.SetTrigger("isBlastDash");
            currentKi -= 50;
        }
    }

    public void BlastDashDamage()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - damage * 4f * attackBoost;
        pAnim.SetTrigger("isDamaged");
    }

    public void BlastBarrageAttack()
    {
        if (currentKi < 40)
        {
            Debug.Log("Too little Ki");
            EnemyAI();
        }
        else
        {
            eAnim.SetTrigger("isBarrage");
        }
    }

    public void SpawnBlast()
    {
        GameObject enemyBlast = Instantiate(blast, new Vector3(7.08f, 3.857f, -1), Quaternion.Euler(0,180,0));
        enemyBlast.GetComponent<Rigidbody2D>().velocity = new Vector3(-8, 0, 0);
        currentKi -= 20;
    }

    public void BlastBarrageDamage()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - damage * 1.5f * attackBoost;
        pAnim.SetTrigger("isDamaged");
    }

    private void PowerUp()
    {
        eAnim.SetTrigger("isPowerUp");
        attackBoost = attackBoost + 0.1f;
        //TurnController.TurnChange();
    }

    public void ResetBoost()
    {
        attackBoost = 1;
    }

    public void EnemyAI()
    {
        //Generate a number and use to determine which attack to use.
        choice = Random.Range(min, max);
        print("choice is" + choice);
        if (choice <= 20)
        {
            KickAttack();
        }
        else if (choice > 20 && choice <= 50)
        {
            PunchAttack();
        }
        else if (choice > 50 && choice <= 70)
        {
            PowerUp();
        }
        else if (choice > 70 && choice <= 90)
        {
            BlastBarrageAttack();
        }
        else if (choice > 90 && choice <= 100)
        {
            BlastDashAttack();
        }
    }

    public void EnemyAttackController()
    {
        if(TurnController.playerTurn == true)
        {
            Debug.Log("Not Enemy Turn");
        }else if (TurnController.playerTurn == false)
        {
            EnemyAI();
        }
    }

    private void TurnChanger()
    {
        Debug.Log("ETurnChanger Triggered");
        TurnController.TurnChange();
        
    }

}
