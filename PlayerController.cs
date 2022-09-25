//MAD IMPORTANT:
//UPDATE GITHUB BEFORE ANYTHING ELSE. YOU MADE THE CODE FOR THE PLAYER ATTACKS, THE LOCKED DOOR MESSAGE, AND THE CODE TO DAMAGE THE ENEEMY WHEN THE PLAYER ATTACKS IT.
//UPDATE TRELLO WITH WHAT YOU'VE DONE. LOCKED DOOR AND KEY CODING, YOU GOT THE LOCKED DOOR MESSAGE WORKING, AND THE TRIGGER DELETES ITSELF.
//FIGURE OUT HOW TO FIX THE PLAYER BEING ABLE TO MOVE UPWARDS AFTER THE TRIGGER IS DELETED.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{ 
    //Initialises variables that are used later in the program.
    public bool upBlocked;
    public bool downBlocked;
    public bool leftBlocked;
    public bool rightBlocked;
    public bool playerMovementStop;
    public bool playerNoAttack;
    public bool playerHasKey;
    public bool playerInCombat;
    public bool playerTurn;
    public int playerMovesRemaining;
    public int PlayerHealth;
    //Initialises the variables that are used to deliver the game over message. The textBox refers to the UI GameObject, the textBoxTextComponent refers to the child of that object which is the UI Text component, and the gameOverMessage refers to the words that will be displayed.
    //smallText refers to the smaller text object that is a child of the text box. Empty refers to the text that will be displayed inside the smallText. In this case the small text shoudl remain blank.
    public GameObject textBox;
    public Text textBoxTextComponent;
    private string gameOverMessage;
    public Text smallText;
    private string Empty;
    //Initialises the GameObject variable from the Unity. This is used to reference the Player object that this script is attatched to.
    public GameObject Self;
    //Initialises the Vector2 variable from the UnityEngine library. The Vector variables store data about the position of objects in the game scene. Vector2 is used for the first 2 dimensions, x and y. This is more appropriate for a 2D environment than the more common Vector3, as only having to manage 2 dimensions reduces the chance for bugs or coding errors.
    public Vector2 playerPosition;

    //Initialises four GameObject variables, called playerUpAttack, playerDownAttack, playerLeftAttack, and playerRightAttack. These are used to initialise and destroy the prefabricated objects for the player's attacks in combat. 
    public GameObject playerUpAttack;
    public GameObject playerDownAttack;
    public GameObject playerLeftAttack;
    public GameObject playerRightAttack;

    //The Start method is called at the beginning of the game, before the first frame update (before any calls of the Update method).
    void Start()
    {
        playerTurn = true;
        gameOverMessage = "You Died. Press enter/return to return to the main menu";
        Empty = "";
    }

    // Update is called once per frame during gameplay.
    void Update() {
        
        //Makes the playerPosition variable equal to the position of the Player object's transform in the scene, making playerPosition store the location of the Player object.
        playerPosition = transform.position;
        
        //Checks if the playerMovementStop variable is false to run the seeded code. This is done so that the Player object can be forced to not move for things such as dialog, and during the enemy's turn in combat.
        if(playerMovementStop == false && playerTurn == true) {
            //Checks for input from the W key.
            if(Input.GetKeyDown(KeyCode.W)) {
                //Checks that the upBlocked variable is false, and therefore the tile upwards/north of the Player object isn't blocked. 
                //This is done to stop the player from beeing able to move through walls and other impassable objects.
                //Blocking the player with a regular collider doesn't work with the way that player movement is being run. Instantly transforming the Player object means that it can wind up inside of colliders, which causes the physics engine to eject the Player object from the collider at odd angles and directions.
                if(upBlocked == false) {
                    //Checks that the Player object's position is within the upper y limit of the screen. This is done to avoid the player travelling out of bounds.
                    if(playerPosition.y <= 3.5) {
                        //Moves the Player object one scene unit upwards/north.
                        transform.Translate(0f, 1f, 0f); }}
            //Checks for input from the S key.
            } else if(Input.GetKeyDown(KeyCode.S)) {
                //Checks that the moveDown variable is true, and therefore the tile downwards/south of the Player object isn't blocked. 
                //This is done to stop the player from beeing able to move through walls and other impassable objects.
                //Blocking the player with a regular collider doesn't work with the way that player movement is being run. Instantly transforming the Player object means that it can wind up inside of colliders, which causes the physics engine to eject the Player object from the collider at odd angles and directions.
                if(downBlocked == false) {
                    //Checks that the Player object's position is within the lower y limit of the screen. This is done to avoid the player travelling out of bounds.
                    if(playerPosition.y >= -5) {
                        //Moves the Player object one unit downwards/south.
                        transform.Translate(0f, -1f, 0f); }
                }
            //Checks for input from the D key.
            } else if(Input.GetKeyDown(KeyCode.D)) {
                //Checks that the moveRight variable is true, and therefore the tile to the right/east of the Player object isn't blocked. 
                //This is done to stop the player from beeing able to move through walls and other impassable objects.
                //Blocking the player with a regular collider doesn't work with the way that player movement is being run. Instantly transforming the Player object means that it can wind up inside of colliders, which causes the physics engine to eject the Player object from the collider at odd angles and directions.
                if(rightBlocked == false) {
                    //Checks that the Player object's position is within the upper x limit of the screen. This is done to avoid the player travelling out of bounds.
                    if(playerPosition.x <= 8) {
                        //Moves the Player object one unit to the right/east.
                        transform.Translate(1f, 0f, 0f); }
                }
            //Checks for input from the A key.
            } else if(Input.GetKeyDown(KeyCode.A)) {
                //Checks that the moveLeft variable is true, and therefore the tile to the left/west of the Player object isn't blocked. 
                //This is done to stop the player from beeing able to move through walls and other impassable objects.
                //Blocking the player with a regular collider doesn't work with the way that player movement is being run. Instantly transforming the Player object means that it can wind up inside of colliders, which causes the physics engine to eject the Player object from the collider at odd angles and directions.
                if(leftBlocked == false) {
                    //Checks that the Player object's position is within the upper x limit of the screen. This is done to avoid the player travelling out of bounds.
                    if(playerPosition.x >= -8) {
                        //Moves the Player object one unit to the left/west.
                        transform.Translate(-1f, 0f, 0f); }
                }
            }

            if(PlayerHealth <= 0) {
                textBoxTextComponent.text = gameOverMessage;
                smallText.text = Empty;
                textBox.SetActive(true);
                Destroy(Self);
            }
        }

        //Proceeds with the seeded instructions if the playerNoAttack variable is false, i.e if it is appropriate for the player to attack in this instance.
        if(playerNoAttack == false && playerInCombat == true && playerTurn == true) {
            //Proceeds with the seeded code if the computer is recieving input from the UpArrow Key (the up arrow is currently being pressed) AND the upBlocked boolean is false.
            if(Input.GetKeyDown(KeyCode.UpArrow) && upBlocked == false) {
                //Creates a clone of the prefab object playerUpAttack 1 spacial unit upwards (towards positive y) of the player's current position.
                GameObject playerUpAttackTemp = Instantiate(playerUpAttack, playerPosition + new Vector2(0,1), transform.rotation) as GameObject;
                Destroy(playerUpAttackTemp, 0.3f);
                playerTurn = false;
            }
            //Proceeds with the seeded code if the computer is recieving input from the DownArrow Key (the down arrow is currently being pressed) AND the downBlocked boolean is false.
            if(Input.GetKeyDown(KeyCode.DownArrow) && downBlocked == false) {
                //Creates a clone of the prefab object playerDownAttack 1 spacial unit downwards (towards negative y) of the player's current position.
                GameObject playerDownAttackTemp = Instantiate(playerDownAttack, playerPosition + new Vector2(0,-1), transform.rotation) as GameObject;
                Destroy(playerDownAttackTemp, 0.3f);
                playerTurn = false;
            }
            //Proceeds with the seeded code if the computer is recieving input from the LeftArrow Key (the left arrow is currently being pressed) AND the leftBlocked boolean is false.
            if(Input.GetKeyDown(KeyCode.LeftArrow) && leftBlocked == false) {
                //Creates a clone of the prefab object playerLeftAttack 1 spacial unit to the left (towards negative x) of the player's current position.
                GameObject playerLeftAttackTemp = Instantiate(playerLeftAttack, playerPosition + new Vector2(-1,0), transform.rotation) as GameObject;
                Destroy(playerLeftAttackTemp, 0.3f);
                playerTurn = false;
            }
            //Proceeds with the seeded code if the computer is recieving input from the RightArrow Key (the right arrow is currently being pressed) AND the rightBlocked boolean is false.
            if(Input.GetKeyDown(KeyCode.RightArrow) && rightBlocked == false) {
                //Creates a clone of the prefab object playerRightAttack 1 spacial unit to the right (towards positive x) of the player's current position.
                GameObject playerRightAttackTemp = Instantiate(playerRightAttack, playerPosition + new Vector2(1,0), transform.rotation) as GameObject;
                Destroy(playerRightAttackTemp, 0.3f);
                playerTurn = false;
            }
        }
    }

    //A method that runs when the collider component of the Player object detects collision with another object's collider that is set to "is trigger".
    private void OnTriggerEnter2D(Collider2D other) {
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "upBlocked".
        if(other.CompareTag("upBlocked")) {
            //Sets the variable "upBlocked" to true. This is used to stop the Player object from being able to move upwards when it shouldn't, i.e there's something in the way.
            upBlocked = true;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "downBlocked".
        } else if(other.CompareTag("downBlocked")) {
            //Sets the variable "upBlocked" to true. This is used to stop the Player object from being able to move downwards when it shouldn't, i.e there's something in the way.
             downBlocked = true;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "leftBlocked".
        } else if(other.CompareTag("leftBlocked")) {
            //Sets the variable "upBlocked" to true. This is used to stop the Player object from being able to move left when it shouldn't, i.e there's something in the way.
             leftBlocked = true;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "rightBlocked".
        } else if(other.CompareTag("rightBlocked")) {
            //Sets the variable "upBlocked" to true. This is used to stop the Player object from being able to move right when it shouldn't, i.e there's something in the way.
            rightBlocked = true;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "Doorway".
        } else if(other.CompareTag("Doorway")) {
            //Sets the variables "leftBlocked" and "rightBlocked" to true. This is only used once, for when the Player object is in the doorway of the stone building, and shouldn't be able to move left or right.
            leftBlocked = true;
            rightBlocked = true;
        }
        if(other.CompareTag("Enemy")) {
            PlayerHealth = 0;
        }
        if(other.CompareTag("enemyAttack")) {
            PlayerHealth -= 1;
        }
    }

    //A method that runs when the collider component of the Player object detects that the collider has exited the collider of a foreign GameObject.
    private void OnTriggerExit2D(Collider2D other) {
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "upBlocked".
        if(other.CompareTag("upBlocked")) {
            //Sets the variable "upBlocked" to false. This is used to give the Player object the ability to move upwards again, once there is no longer anything blocking its path.
            upBlocked = false;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "downBlocked".
        } else if(other.CompareTag("downBlocked")) {
            //Sets the variable "downBlocked" to false. This is used to give the Player object the ability to move downwards again, once there is no longer anything blocking its path.
            downBlocked = false;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "leftBlocked".
        } else if(other.CompareTag("leftBlocked")) {
            //Sets the variable "leftBlocked" to false. This is used to give the Player object the ability to move left again, once there is no longer anything blocking its path.
            leftBlocked = false;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "rightBlocked".
        } else if(other.CompareTag("rightBlocked")) {
            //Sets the variable "rightBlocked" to false. This is used to give the Player object the ability to move right again, once there is no longer anything blocking its path.
            rightBlocked = false;
        //Checks the tag of the foreign GameObject. Proceeds with seeded instruction if the tag is "Doorway".
        } else if(other.CompareTag("Doorway")) {
            //Sets the variables "leftBlocked" and "rightBlocked" to false. This is only used once, for when the Player object leaves the doorway of the stone building, where it shouldn't have been able to move left or right.
            leftBlocked = false;
            rightBlocked = false;
        } else if(other.CompareTag("lockedDoor")) {
            //Sets the variable "upBlocked" to true. This is used once to avoid a glitch that allows the playre to move through the locked door.
            upBlocked = true;
        }
    }
}
