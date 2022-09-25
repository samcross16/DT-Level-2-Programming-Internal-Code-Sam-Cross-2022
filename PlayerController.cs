//MAD IMPORTANT:
//MAKE NOTES IN TRELLO ABOUT STOPPING THE PLAYER DURING EVENTS CODE.
//ALSO REMEMBER TO UPDATE GITHUB NOW AND AT END OF LESSON.
//FINISH COMMENTS.
//UPDATE TRELLO WITH REST OF THIS SPRINT'S TO-DO'S: COMBAT SYSTEM, ENEMY SPRITES, CHANGING BETWEEN SCENES ON BUTTON PRESS, MAIN MENU SCREEN, UI, AND FINALLY PUTTING THE REST OF IT TOGETHER TO MAKE A FUNCTIONING GAME.
//THEN START ON COMBAT SYSTEM.

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
    //Initialises the Vector2 variable unique to the Unity engine. The Vector variables store data about the position of objects in the game scene. Vector2 is used for the first 2 dimensions, x and y. This is more appropriate for a 2D environment than the more common Vector3, as only having to manage 2 dimensions reduces the chance for bugs or coding errors.
    public Vector2 playerPosition;

    public GameObject playerUpAttack;
    public GameObject playerDownAttack;
    public GameObject playerLeftAttack;
    public GameObject playerRightAttack;
    // Start is called at the beginning of the game, before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        
        //Makes the playerPosition variable equal to the position of the Player object's transform in the scene, making playerPosition store the location of the Player object.
        playerPosition = transform.position;
        
        //Checks if the playerMovementStop variable is false to run the seeded code. This is done so that the Player object can be forced to not move for things such as dialog, and during the enemy's turn in combat.
        if(playerMovementStop == false) {
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
        }
        if(playerNoAttack == false) {
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                GameObject playerUpAttackTemp = Instantiate(playerUpAttack, playerPosition + new Vector2(0,1), transform.rotation) as GameObject;
                //playerNoAttack = true;
                Destroy(playerUpAttackTemp, 0.3f);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow)) {
                GameObject playerDownAttackTemp = Instantiate(playerDownAttack, playerPosition + new Vector2(0,-1), transform.rotation) as GameObject;
                //playerNoAttack = true;
                Destroy(playerDownAttackTemp, 0.3f);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                GameObject playerLeftAttackTemp = Instantiate(playerLeftAttack, playerPosition + new Vector2(-1,0), transform.rotation) as GameObject;
                //playerNoAttack = true;
                Destroy(playerLeftAttackTemp, 0.3f);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)) {
                GameObject playerRightAttackTemp = Instantiate(playerRightAttack, playerPosition + new Vector2(1,0), transform.rotation) as GameObject;
                //playerNoAttack = true;
                Destroy(playerRightAttackTemp, 0.3f);
            }
        }
    }
    //A method that runs when the collider component of the Player object detects collision with another object's collider that is set to "is trigger".
    private void OnTriggerEnter2D(Collider2D other) {
        //Checks the tag of the foreign 
        if(other.CompareTag("upBlocked")) {
            upBlocked = true;
        } else if(other.CompareTag("downBlocked")) {
             downBlocked = true;
        } else if(other.CompareTag("leftBlocked")) {
             leftBlocked = true;
        } else if(other.CompareTag("rightBlocked")) {
            rightBlocked = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("upBlocked")) {
            upBlocked = false;
        } else if(other.CompareTag("downBlocked")) {
            downBlocked = false;
        } else if(other.CompareTag("leftBlocked")) {
            leftBlocked = false;
        } else if(other.CompareTag("rightBlocked")) {
            rightBlocked = false;
        }
    }
}
