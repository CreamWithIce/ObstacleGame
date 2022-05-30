using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class DeathScreenMenuOptions : MonoBehaviour
{
    public Timer timer;
    public TMP_Text text;

    // Stops the timer from timing and gets the time from the timer
    void Start(){
        timer.IsTiming = false;
        text.text = timer.time.ToString();
    }

    // Will send you back to the scene at build index 0 and resets time scale
    public void ToMainMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        
    }

    // Reloads the current scene you are in
    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Resets time scale
        timer.time = 0f; // Redundant reset of time since level is reloaded
    }


}
