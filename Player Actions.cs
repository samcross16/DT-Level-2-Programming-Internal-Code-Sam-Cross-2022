using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAction : MonoBehaviour
{
    //This creates a set of publicly accessible GameObjects that can be referenced within this script.
    //Being public enables these to be accessed outside the script (i.e in the game engine editor).
    //playerActionsMenu will be used to open and close a menu of actions the player can take in the game.
    public GameObject playerActionsMenu;
    //attackDialogBox will be used to create a dialog on screen when the player tries to attack when there is no enemy nearby.
    public GameObject attackDialogBox;
    //This is a publicly accessible boolean variable called playerActionMenuOpen.
    //This will be used to check whether or not the actions menu is currently active in the game environment.
    public bool playerActionsMenuOpen;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            if(playerActionsMenuOpen == false) {
                playerActionsMenuOpen = true;
                playerActionsMenu.SetActive(true);
                //if(Input.GetKeyDown(KeyCode.Alpha1)) { } Need a list of all of the key codes in that the unity engine uses.
            }
        }
    }
}