using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlock : MonoBehaviour
{
    public GameObject PlayerObject;
    private PlayerController PlayerVariables;
    public GameObject textBox;
    public bool playerInRange_doorUnlock;
    private string doorUnlockQueryWords;
    private string doorUnlockButtonToPress;
    private string doorUnlockedWords;
    private string clearMessageButtonToPress;
    public Text textBoxText;
    public Text textBoxContinueMessage;
    public bool doorUnlockQueryCleared;
    public GameObject DoorUnlockQueryTrigger;
    public GameObject textBox_lockedDoor_Trigger;
    // Start is called before the first frame update
    void Start()
    {
        PlayerVariables = PlayerObject.GetComponent<PlayerController>();
        playerInRange_doorUnlock = false;
        doorUnlockQueryWords = "Use your rusted key on this door? (You can still walk away now.)";
        doorUnlockButtonToPress = "Press E to use";
        doorUnlockedWords = "Your key fits the hole, and you turn it. The tumblers are stuck with age, and take a great effort to fully unlock. When you do, the rusted key gives out, snapping in your hand. The door swings open.";
        clearMessageButtonToPress = "press space";
        doorUnlockQueryCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange_doorUnlock == true && Input.GetKeyDown(KeyCode.E)) {
            doorUnlockQueryCleared = true;
            textBox.SetActive(false);
            PlayerVariables.playerMovementStop = true;
        }

        if(doorUnlockQueryCleared == true) {
            textBoxText.text = doorUnlockedWords;
            textBoxContinueMessage.text = clearMessageButtonToPress;
            textBox.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) {
                PlayerVariables.playerMovementStop = false;
                Destroy(textBox_lockedDoor_Trigger);
                PlayerVariables.upBlocked = false;
                Destroy(DoorUnlockQueryTrigger);
            }
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)  {
        if(other.CompareTag("Player")) {
            PlayerVariables.upBlocked = true;
            playerInRange_doorUnlock = true;
            if(PlayerVariables.playerHasKey == true) {
                textBoxText.text = doorUnlockQueryWords;
                textBoxContinueMessage.text = doorUnlockButtonToPress;
                textBox.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        doorUnlockQueryCleared = false;
        PlayerVariables.upBlocked = false;
        textBox.SetActive(false);
        playerInRange_doorUnlock = false;
    }
}
