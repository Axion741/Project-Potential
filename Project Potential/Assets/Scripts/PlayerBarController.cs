using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarController : MonoBehaviour {

    
    private float fillValue;

    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private Image kiBar;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleHealthBar();
	}

    private void HandleHealthBar()
    {
        fillValue = PlayerStats.currentHealth /PlayerStats.maxHealth;
        healthBar.fillAmount = fillValue;
    }

    private void HandleKiBar()
    {
        fillValue = PlayerStats.currentKi / PlayerStats.maxKi;
        healthBar.fillAmount = fillValue;
    }
}
