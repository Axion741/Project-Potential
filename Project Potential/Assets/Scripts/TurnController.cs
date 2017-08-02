using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour {

    static bool playerTurn;
    public static GameObject ControlBlocker;

	// Use this for initialization
	void Start () {
        playerTurn = true;
        ControlBlocker = GameObject.Find("Control Blocker");
        UIController();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public static void TurnChange()
    {
        if (playerTurn == true)
        {
            playerTurn = false;
            UIController();
        }
        else if(playerTurn == false)
        {
            playerTurn = true;
            UIController();
        }
    }

    public static void UIController()
    {
        if (playerTurn == true)
        {
            print("PlayerTurn");
            //Delay here
            ControlBlocker.SetActive(false);
        }
        else if (playerTurn == false)
        {
            print("EnemyTurn");
            ControlBlocker.SetActive(true);
        }
    }
}
