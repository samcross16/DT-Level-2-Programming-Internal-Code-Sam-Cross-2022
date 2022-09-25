using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{

    //Initialising variables here to make code more digestable.

    //A GameObject called textBox_lockedDoor. This is the box that appears on screen to tell the player the door is locked.
    public GameObject textBox_lockedDoor;
    //A sting variable called dialogWords_lockedDoor. This variable stores the words that will be displayed in the text box.
    public string dialogWords_lockedDoor;
    //A boolean variable called playerInRange. This will be used for determining whether or not the player is inside the area that they should be for the text box should appear on the screen.
    public bool playerInRange_lockedDoor;
    //A Text variable called dialogText_lockedDoor. The Text variable is unique to the UnityEngine.UI library. 
    //This is the UI component that displays the message that is to appear inside the text box.
    public Text dialogText_lockedDoor;
    //This is used to access the Player object's components (the PlayerController script & class for this purpose) later in this script.
    public GameObject PlayerObject;
    //References the PlayerController class from the PlayerController script. this allows the variables from the PlayerController class to be accessed for use in this script.
    private PlayerController PlayerVariables;
    void Start () {
        PlayerVariables = PlayerObject.GetComponent<PlayerController>();
        textBox.SetActive(false);
    }
    //The Update method is called once each frame while the game is running.
    void Update () {
        //Checks if the player is currently inside the desired range for the textBox to appear.
        if(playerInRange == true) {
                //.activeInHierarchy checks if an object is currently "active" in the game scene, meaning the object is currently in the game environment.
                //The textBox is the object that is being checked for activity in this instance.
                //Checks for the space key being pressed. 
                //The .GetKeyDown function works for single button presses as it only checks once before needing to be reset by the key coming back up.
                if(Input.GetKeyDown(KeyCode.Space) && textBox.activeInHierarchy) {
                    //Sets the textBox object to inactive in the scene.
                    textBox.SetActive(false);
                    //Accesses the playerMovementStop variable from the PlayerController class in the PlayerController script and sets it to false.
                    //This enables movement of the Player object again, as the textBox object is no longer active in the scene.
                    PlayerVariables.playerMovementStop = false;
                    PlayerVariables.playerNoAttack = false;
                    //Destroys this script to prevent the textBox from reappearing next frame.
                    Destroy(this);
               }
            
            else {
                //Sets the text box active in the scene.
                textBox.SetActive(true);
                dialogText.text = dialogWords;
                PlayerVariables.playerMovementStop = true;
                PlayerVariables.playerNoAttack = true;
            }
        }
    }

    //The OnTriggerEnter2D method is called whenever another collider is detected as having entered a collider that is a component of the game object associated with this script.
    //This only applies if the collider of this scripts associated object is set to isTrigger in the editor.
    //Foreign object is referenced as other for simplicity.
    private void OnTriggerEnter2D(Collider2D other) {
        //Checks if the Tag of the foreign object is "Player".
        if(other.CompareTag("Player")){
            //Sets the playerInRange variable to true. This is done so that this information can be carried over to and checked in the Update method.
            playerInRange = true;
        }
    }
    //The OnTriggerExit2D method works in the same way as the OnTriggerEnter method above, except gor when another collider is detected as having exited the collider of this scripts associated game object (must be set to isTrigger).
    private void OnTriggerExit2D(Collider2D other) {
        //Checks if the Tag of the foreign object is "Player".
        if(other.CompareTag("Player")){
            //Sets the playerInRange variable to false. This is done so that this information can be carried over to and checked in the Update method.
            playerInRange = false;
            textBox.SetActive(false);
        }
    }
}
