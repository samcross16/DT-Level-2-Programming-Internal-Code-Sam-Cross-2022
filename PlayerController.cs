//MAD IMPORTANT:
//MAKE NOTES IN TRELLO ABOUT STOPPING THE PLAYER DURING EVENTS CODE.
//ALSO REMEMBER TO UPDATE GITHUB NOW AND AT END OF LESSON.
//FINISH COMMENTS.
//UPDATE TRELLO WITH REST OF THIS SPRINT'S TO-DO'S: COMBAT SYSTEM, ENEMY SPRITES, CHANGING BETWEEN SCENES ON BUTTON PRESS, MAIN MENU SCREEN, UI, AND FINALLY PUTTING THE REST OF IT TOGETHER TO MAKE A FUNCTIONING GAME.
//THEN START ON COMBAT SYSTEM.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    //Initialises variables that are used later in the program.
    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;
    public bool playerMovementStop;
    //Initialises the Vector2 variable unique to the Unity engine. The Vector variables store data about the position of objects in the game scene. Vector2 is used for the first 2 dimensions, x and y. This is more appropriate for a 2D environment than the more common Vector3, as only having to manage 2 dimensions reduces the chance for bugs or coding errors.
    public Vector2 playerPosition;
    
    // Start is called at the beginning of the game, before the first frame update
    void Start()
    {
        //Sets moveUp, moveDown, moveRight, and moveLeft to true. This allows the Player object to move in any direction at the start of the program.
        moveUp = true;
        moveDown = true;
        moveLeft = true;
        moveRight = true;
        //Sets playerMovementStop to false. This allows the player to move. playerMovementStop is set to true during times the Player object shouldn't be moving. In this proof of concept these scenarios are when dialog or meny text appears on screen, and when the player is in combat and it is the enemy's turn. 
        playerMovementStop = false;
    }

    // Update is called once per frame
    void Update() {
        
        //Makes the playerPosition variable equal to the position of the Player object's transform in the scene, making playerPosition store the location of the Player object.
        playerPosition = transform.position;
        
        //Checks if the playerMovementStop variable is false to run the seeded code. This is done so that the Player object can be forced to not move for things such as dialog, and during the enemy's turn in combat.
        if(playerMovementStop == false) {
            //Checks for input from the W key.
            if(Input.GetKeyDown(KeyCode.W)) {
                //Checks that the moveUp variable is true, and therefore the tile upwards/north of the Player object isn't blocked. 
                //This is done to stop the player from beeing able to move through walls and other impassable objects.
                //Blocking the player with a regular collider doesn't work with the way that player movement is being run. Instantly transforming the Player object means that it can wind up inside of colliders, which causes the physics engine to eject the Player object from the collider at odd angles and directions.
                if(moveUp == true) {
                    //Checks that the Player object's position is within the upper y limit of the screen. This is done to avoid the player travelling out of bounds.
                    if(playerPosition.y <= 3.5) {
                        //Moves the Player object one scene unit upwards/north.
                        transform.Translate(0f, 1f, 0f); }}
            //Checks for input from the S key.
            } else if(Input.GetKeyDown(KeyCode.S)) {
                //Checks that the moveDown variable is true, and therefore the tile downwards/south of the Player object isn't blocked. 
                //This is done to stop the player from beeing able to move through walls and other impassable objects.
                //Blocking the player with a regular collider doesn't work with the way that player movement is being run. Instantly transforming the Player object means that it can wind up inside of colliders, which causes the physics engine to eject the Player object from the collider at odd angles and directions.
                if(moveDown == true) {
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
                if(moveRight == true) {
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
                if(moveLeft == true) {
                    //Checks that the Player object's position is within the upper x limit of the screen. This is done to avoid the player travelling out of bounds.
                    if(playerPosition.x >= -8) {
                        //Moves the Player object one unit to the left/west.
                        transform.Translate(-1f, 0f, 0f); }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("upBlocked")) {
            moveUp = false;
        } else if(other.CompareTag("downBlocked")) {
             moveDown = false;
        } else if(other.CompareTag("leftBlocked")) {
             moveLeft = false;
        } else if(other.CompareTag("rightBlocked")) {
            moveRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("upBlocked")) {
            moveUp = true;
        } else if(other.CompareTag("downBlocked")) {
            moveDown = true;
        } else if(other.CompareTag("leftBlocked")) {
            moveLeft = true;
        } else if(other.CompareTag("rightBlocked")) {
            moveRight = true;
        }
    }
}
