using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("UI")]
    public GameObject GameOverScreen; // Game over when you restart
    public GameObject HUD; // The hud for the timer

    [Header("Jump\n")]

    public Checks[] checks; // the custom array of structs
    Vector3 velocity; // Gravity and jump vector
    public float gravity = -9.81f;

    
    [Header("Movement\n")]

    public float speed = 12f;
    public float airStrafeSpeed = 5f;
    public float drag = 2f;
    float OriginalSpeed;

    public CharacterController player;

    Vector3 momentum; // For players momentum in air to keep the player moving
    Vector3 playerMovement;

    Vector3 getX;
    Vector3 getZ;

    

    void Start(){
        OriginalSpeed = speed; // Original speed is used to reset the players speed to default walking speed
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        velocity.y += gravity * Time.deltaTime; // Sets the standard gravity

        // Gets input from  the player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Function call taking the input movements as arguments
        MovementChecks(x,z);

        // makes a Vector3 taking in the x and z as values and gets the direction of the player in 
        Vector3 move = transform.right * x + transform.forward * z;
        
        player.Move(move * Time.deltaTime * speed); // Moves the player at a certain speed
        player.Move(momentum * Time.deltaTime); // Moves the player for the momentum they have gained in the air
        player.Move(velocity * Time.deltaTime); // Adds gravity to the player
    }


    // Does all the movement checks and modifies values related to movement accordingly
    void MovementChecks(float x,float z){
        // Loops over the array of structs
        for(int i = 0; i < checks.Length; i++){

            // Raycasts a sphere to a given surface checking for a given layer inside of an array of structs
            checks[i].isOnSurface = Physics.CheckSphere(checks[i].CheckPos.position,checks[i].size,checks[i].layer);

           
            if(checks[i].isOnSurface && Input.GetButtonDown("Jump")){
                velocity.y = Mathf.Sqrt(checks[i].jumpHeight * -2f * gravity); // Calculation for jump height
                speed = airStrafeSpeed; // Changes player speed to be the speed of movement in the air

                if(checks[i].type == "Ground"){
                    // Gets the speed at the time of jumping and the direction of jumping and puts it into vectors
                    getX = (x * speed / drag) * transform.right;
                    getZ = (z * speed / drag) * transform.forward;
                }
            }
            // Checks if you have touched a surface with a custom type of restart (it is a string)
            if(checks[i].isOnSurface && checks[i].type == "Restart"){
                // Unlocks the cursor, freezes time and replaces the timer UI overlay with a death screen
                Time.timeScale = 0f;
                HUD.SetActive(false);
                GameOverScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }

            // Sets the Vector3 to be an addition of the calculation for the x and z if it isn't on the ground
            if(!checks[i].isOnSurface && checks[i].type == "Ground"){
                momentum = getX + getZ;
            }

            // Resets everything to default that has been modified accordingly
            if(checks[i].isOnSurface && velocity.y < 0  && checks[i].type == "Ground"){
                velocity.y = -2f; // Makes sure the player is truely on the ground
                momentum = new Vector3(0f,0f,0f);
                speed = OriginalSpeed;
            }
        }
    }
}

// All the data in each element of the array
[System.Serializable]
public struct Checks{
    public Transform CheckPos; // Provides a position for the raycast sphere
    public LayerMask layer; // Provides a layer for the raycast sphere to check for
    public float size; // How big the raycast sphere should be
    
    public bool isOnSurface; // Contains its own bool for jumping
    public string type; // The type of surface for different interactions e.g. Ground, Restart, Wall (Hard coded)
    public float jumpHeight; // How high you can jump in each element of the array
}