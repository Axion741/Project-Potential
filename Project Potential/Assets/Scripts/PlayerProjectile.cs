using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public GameObject player;
    private PlayerStats playerStats;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("PlayerCharacter");
        playerStats = player.GetComponent<PlayerStats>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D impact)
    {
        Debug.Log("Collision");
        playerStats.BlastBarrageDamage();
        Destroy(gameObject);
    }
}
