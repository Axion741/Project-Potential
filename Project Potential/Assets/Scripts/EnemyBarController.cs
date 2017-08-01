using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBarController : MonoBehaviour {

    private float fillValue;

    [SerializeField]
    private Image bar;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        fillValue = EnemyStats.currentHealth / EnemyStats.maxHealth;
        bar.fillAmount = fillValue;
    }
}


