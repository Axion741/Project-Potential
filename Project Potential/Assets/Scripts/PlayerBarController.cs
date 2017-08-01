using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarController : MonoBehaviour {

    
    private float fillValue;

   [SerializeField]
    private Image bar;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        fillValue = PlayerStats.currentHealth /PlayerStats.maxHealth;
        bar.fillAmount = fillValue;
    }
}
