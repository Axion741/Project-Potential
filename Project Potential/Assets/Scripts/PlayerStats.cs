using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour {

    public static float currentHealth;

    public static float maxHealth = 100;

    private Animator pAnim;
    private Animator eAnim;
    public GameObject enemy;
    

    // Use this for initialization
    void Start()
    {
        eAnim = enemy.GetComponent<Animator>();
        pAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        print(currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            pAnim.SetBool("isDead", true);
        }
    }

    public void DealDamage()
    {
        EnemyStats.currentHealth = EnemyStats.currentHealth - 10;
        eAnim.SetTrigger("isDamaged");
    }
}