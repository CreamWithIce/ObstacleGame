using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public Transform pb;
    public float sensetivity = 100f;
    
    float xRotation;

    void Start(){
        
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor so it won't move around
        
    }
    // Update is called once per frame
    void Update()
    {
        // Gets mouses position 
        float mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

        // Subtracts the mouseY and clamps it between 90 and -90 degrees
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90,90);
        // Rotates the object it is attached to on its local x axis
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

        // Rotates the GameObject referenced on the y axis
        pb.Rotate(Vector3.up * mouseX);

    }
}
