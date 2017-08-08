using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public GameObject enemy;
    private EnemyStats enemyStats;

    // Use this for initialization
    void Start()
    {
        enemy = GameObject.Find("EnemyCharacter");
        enemyStats = enemy.GetComponent<EnemyStats>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D impact)
    {
        Debug.Log("Collision");
        enemyStats.BlastBarrageDamage();
        Destroy(gameObject);
    }
}