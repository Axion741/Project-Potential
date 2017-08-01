using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour {

    
    public static float playerCurrentHealth;

    public static float playerMaxHealth = 100;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        print(playerCurrentHealth);

        if (playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        else if (playerCurrentHealth <= 0)
        {
            anim.SetBool("isDead", true);
        }
	}

    public void DamageTaken()
    {
        playerCurrentHealth = playerCurrentHealth - 10;
        anim.SetTrigger("isDamaged");
    }
}
