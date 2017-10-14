using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour {

    public Canvas resultsCanvas;
    public Text titleText;
    public Text pointText;
    public Text pointMessage;
    private PlayerAbilities playerAbilities;
    private EnemyStats enemyStats;


	// Use this for initialization
	void Start () {
        resultsCanvas = resultsCanvas.GetComponent<Canvas>();
        resultsCanvas.enabled = false;
        playerAbilities = FindObjectOfType<PlayerAbilities>();
        enemyStats = FindObjectOfType<EnemyStats>();

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void ResultCanvasEnabler()
    {
        resultsCanvas.enabled = true;
    }

    public void WinFight()
    {
        titleText.text = "Victory!";
        ResultCanvasEnabler();
        playerAbilities.experiencePoints = playerAbilities.experiencePoints + enemyStats.experienceValue;
        playerAbilities.SetExperience();

    }

    public void LoseFight()
    {
        titleText.text = "Defeat!";
        ResultCanvasEnabler();
    }

    public void TextEnabler()
    {
        pointText.text = playerAbilities.statPoints + " Skill Points Available!";
        pointMessage.enabled = true;
    }
}
