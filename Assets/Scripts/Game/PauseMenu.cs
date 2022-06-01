using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour {
    public GameObject PauseUI;
    public bool paused;
    public GameObject GameOverMenu;
    
    void Update(){
        // Checks if the escape key is pressed and changes the paused bool
        if(Input.GetKeyDown("escape")){
            paused = !paused;
        }
        // If the game over menu is showing the pause menu will not be shown
        if(GameOverMenu.activeSelf){
            paused = false;
        }

        if(paused){
            Time.timeScale = 0; // Stops time
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!paused && !GameOverMenu.activeSelf){
            Time.timeScale = 1; // Starts time
            Cursor.lockState = CursorLockMode.Locked;
        }
        PauseUI.SetActive(paused); // Changes the object to be active or not
    }

}