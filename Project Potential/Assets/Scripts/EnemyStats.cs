using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    private Animator eAnim;
    private Animator pAnim;
    public GameObject player;
    int max = 100;
    int min = 1;
    int choice;

    public static float currentHealth;
    public static float maxHealth = 100;
    private float damage = 10;
    private float attackBoost = 1f;


    // Use this for initialization
    void Start () {
        pAnim = player.GetComponent<Animator>();
        eAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        print(currentHealth);

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
        TurnController.TurnChange();
    }

    public void PunchDamage()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - damage * attackBoost;
        pAnim.SetTrigger("isDamaged");
    }

    private void KickAttack()
    {
        eAnim.SetTrigger("isKicking");
        TurnController.TurnChange();
    }

    public void KickDamage()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - damage * 2.5f * attackBoost;
        pAnim.SetTrigger("isDamaged");
    }

    private void PowerUp()
    {
        eAnim.SetTrigger("isPowerUp");
        attackBoost = attackBoost + 0.1f;
        TurnController.TurnChange();
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
        if (choice >= 75)
        {
            KickAttack();
        }
        else if (choice <= 50)
        {
            PunchAttack();
        }
        else
        {
            PowerUp();
        }
    }
}
