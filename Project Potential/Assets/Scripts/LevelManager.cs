using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;
    public static bool cameFromOptionsMenu = false;

    private void Start()
    {
        if(autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Autoload disabled, use positive number in seconds");
        }
        else Invoke("LoadNextLevel", autoLoadNextLevelAfter);

    }

    public void LoadLevel(string name) {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            cameFromOptionsMenu = true;
            Debug.Log("Came from Options True)");
        }else
        {
            cameFromOptionsMenu = false;
            Debug.Log("Came from Options False");
        }

        Debug.Log("Level Load Requested for: " + name);
        SceneManager.LoadScene(name);
       
    }

    public void QuitRequest() {
        Debug.Log("Quit Request logged");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

}
