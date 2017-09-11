using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour {

    public Canvas resultsCanvas;
    public Text titleText;

	// Use this for initialization
	void Start () {
        resultsCanvas = resultsCanvas.GetComponent<Canvas>();
        resultsCanvas.enabled = false;
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
    }

    public void LoseFight()
    {
        titleText.text = "Defeat!";
        ResultCanvasEnabler();
    }
}
