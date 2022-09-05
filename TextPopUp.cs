using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPopUp : MonoBehaviour
{

    //Initialising variables here to make code more digestable.

    //A GameObject called textBox. This is the box that appears on screen to describe a scene for the player.
    public GameObject textBox;
    //A Text UI component called textBoxText. This is what allows the text to be displayed on the screen.
    public Text textBoxText;
    //A sting variable called textBoxWords. This is the actual writing that appears in the text component and on the screen.
    public string textBoxWords;
    //A boolean variable called textBoxActive. This will be used for determining whether or not the text box should appear on the screen.
    public bool textBoxActive;

    //The Update method is called once each frame while the game is running.
    void Update () {

    }

    //The OnTriggerEnter2D method is called whenever a collision is detected between the object this script is attached to, and another object.
    //Foreign object is referenced as other for simplicity.
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            Debug.Log("Player out of range");
        }
    }
}
