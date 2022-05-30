using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    public Int32 length = 3;
    public TMP_Text timer;
    public float time;
    public bool IsTiming = true;
    
    
    void FixedUpdate()
    {
        Time.timeScale = 1f;
        if(IsTiming){
            time += Time.deltaTime;
            timer.text = time.ToString();
        }
    }
}
