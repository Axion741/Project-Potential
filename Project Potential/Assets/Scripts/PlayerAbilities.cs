using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

    private int baseStrength = 10;
    private int baseSpeed = 10;
    private int baseEndurance = 10;
    private int baseSpirit = 10;
    private int baseLevel = 1;

    public int currentStrength;
    public int currentSpeed;
    public int currentEndurance;
    public int currentSpirit;

    public int modStrength;
    public int modSpeed;
    public int modEndurance;
    public int modSpirit;

    public float maxHealth;
    
    public float maxKi;

    public float physicalDamage;
    public float spiritDamage;
    public float evasionChance;
    

    // Use this for initialization
    void Start () {
        GetSavedStats();
        DetermineStrength();
        DetermineSpirit();
        DetermineEndurance();
        DetermineSpeed();
        DetermineHealth();
        DetermineKi();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DetermineHealth()
    {
        maxHealth = currentEndurance*10;
        
    }

    public void DetermineKi()
    {
        maxKi = currentSpirit * 10;
       
    }

    public void DetermineStrength()
    {
        currentStrength = baseStrength + PlayerPrefsManager.GetStrengthMod();
        physicalDamage = currentStrength;
    }

    public void DetermineSpeed()
    {
        currentSpeed = baseSpeed + PlayerPrefsManager.GetSpeedMod();
        evasionChance = currentSpeed / 2;
    }

    public void DetermineEndurance()
    {
        currentEndurance = baseEndurance + PlayerPrefsManager.GetEnduranceMod();
    }

    public void DetermineSpirit()
    {
        currentSpirit = baseSpirit + PlayerPrefsManager.GetSpiritMod();
        spiritDamage = currentSpirit * 1.5f;
    }

    public void LevelStrength()
    {
        modStrength++;
        PlayerPrefsManager.SetStrengthMod(modStrength);
        DetermineStrength();
    }

    public void LevelSpeed()
    {
        modSpeed++;
        PlayerPrefsManager.SetSpeedMod(modSpeed);
        DetermineSpeed();
    }

    public void LevelEndurance()
    {
        modEndurance++;
        PlayerPrefsManager.SetEnduranceMod(modEndurance);
        DetermineEndurance();
        DetermineHealth();
    }

    public void LevelSpirit()
    {
        modSpirit++;
        PlayerPrefsManager.SetSpiritMod(modSpirit);
        DetermineSpirit();
        DetermineKi();
    }

    public void ResetStats()
    {
        modStrength = 0;
        modSpeed = 0;
        modEndurance = 0;
        modSpirit = 0;
        PlayerPrefsManager.SetStrengthMod(modStrength);
        DetermineStrength();
        PlayerPrefsManager.SetSpeedMod(modSpeed);
        DetermineSpeed();
        PlayerPrefsManager.SetEnduranceMod(modEndurance);
        DetermineEndurance();
        PlayerPrefsManager.SetSpiritMod(modSpirit);
        DetermineSpirit();
        DetermineHealth();
        DetermineKi();
    }

    public void GetSavedStats()
    {
        modStrength = PlayerPrefsManager.GetStrengthMod();
        modSpeed = PlayerPrefsManager.GetSpeedMod();
        modEndurance = PlayerPrefsManager.GetEnduranceMod();
        modSpirit = PlayerPrefsManager.GetSpiritMod();
    }
}
