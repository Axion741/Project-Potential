using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    
    public static float currentHealth;

    public static float maxHealth = 100;

    private Animator eAnim;
    private Animator pAnim;
    public GameObject player;

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

    public void DealDamage()
    {
        PlayerStats.currentHealth = PlayerStats.currentHealth - 10;
        pAnim.SetTrigger("isDamaged");
    }
}
