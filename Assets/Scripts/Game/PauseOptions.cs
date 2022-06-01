using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseOptions : MonoBehaviour
{
    PauseMenu pause;

    void Start(){
        pause = FindObjectOfType<PauseMenu>();
        pause.paused = false;
    }

    // Will send you back to the scene at build index 0 and resets time scale
    public void Quit(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Redundant
    }

    // Restarts the scene by its index
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Unpauses the game
    public void play(){
        pause.paused = !pause.paused;
    }
    
}
