using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModNumberController : MonoBehaviour {

    public Text text;

    private int strengthMod;
    private int speedMod;
    private int enduranceMod;
    private int spiritMod;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ButtonChecker();
	}

    public void ButtonChecker()
    {
        if (gameObject.name == "ModStr")
        {
            StrengthText();
        }
        else if (gameObject.name == "ModSpd")
        {
            SpeedText();
        }
        else if (gameObject.name == "ModEnd")
        {
            EnduranceText();
        }
        else if (gameObject.name == "ModSpt")
        {
            SpiritText();
        }
    }

    public void StrengthText()
    {
        strengthMod = PlayerPrefsManager.GetStrengthMod();
        text.text = ("<Color=#00ff00ff>+" + strengthMod.ToString() + "</Color>");
    }

    public void SpeedText()
    {
        speedMod = PlayerPrefsManager.GetSpeedMod();
        text.text = ("<Color=#00ff00ff>+" + speedMod.ToString() + "</Color>");
    }

    public void EnduranceText()
    {
        enduranceMod = PlayerPrefsManager.GetEnduranceMod();
        text.text = ("<Color=#00ff00ff>+" + enduranceMod.ToString() + "</Color>");
    }

    public void SpiritText()
    {
        spiritMod = PlayerPrefsManager.GetSpiritMod();
        text.text = ("<Color=#00ff00ff>+" + spiritMod.ToString() + "</Color>");
    }
}
