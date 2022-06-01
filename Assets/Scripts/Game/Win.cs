using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Win : MonoBehaviour
{
    
    [Header("Win Stuff")]
    public LayerMask playerMask;
    public Transform winTransform;
    public float size = 2f;
    bool win;
    public Timer time;

    [Header("UI Stuff")]
    public GameObject winUI;
    public GameObject Timer;
    public TMP_Text currentTime;


    void Update()
    {
        win = Physics.CheckSphere(winTransform.position,size,playerMask);
        // Creates a sphere to check for a layer the player is attached to
        if(win){
            // Activates the win UI and sets the Timer display to not appear
            winUI.SetActive(true);
            Timer.SetActive(false);

            // Gets the time from the timer script and displays it as text
            currentTime.text = time.time.ToString();
        
            time.IsTiming = false; // stops timer
            Time.timeScale = 0f; // Stops time
            Cursor.lockState = CursorLockMode.None; // Unlocks cursor


        }
    }
}
