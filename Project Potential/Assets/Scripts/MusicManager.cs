using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    
    private AudioSource audioSource;
       

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("DontDestroyOnLoad" + name);
    }
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
       //set volume to saved preference on start
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();

    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip" + thisLevelMusic);

        if (thisLevelMusic && !LevelManager.cameFromOptionsMenu)
        {//if some music attached
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeVolume (float volume)
    {
       audioSource.volume = volume;
    }
}
