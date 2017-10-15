using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSoundController : MonoBehaviour {

    public AudioClip[] attackSounds;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        //set volume to saved preference on start
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FirstPunchSound()
    {
        audioSource.clip = attackSounds[0];
        audioSource.Play();
    }

    public void SecondPunchSound()
    {
        audioSource.clip = attackSounds[1];
        audioSource.Play();
    }

    public void KickSound()
    {
        audioSource.clip = attackSounds[2];
        audioSource.Play();
    }

    public void DashSound()
    {
        audioSource.clip = attackSounds[3];
        audioSource.Play();
    }

    public void DodgeSound()
    {
        audioSource.clip = attackSounds[4];
        audioSource.Play();
    }


}
