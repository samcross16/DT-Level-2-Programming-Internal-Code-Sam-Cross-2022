using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PondScript_KeyForLockedDoor : MonoBehaviour
{
    public GameObject textBox;
    public Text pondDialog;
    public string pondDialogWords;
    private string pondDialog2Words;
    private bool playerInPond;
    public GameObject PlayerObject;
    private PlayerController PlayerVariables;
    public GameObject pondDialogTrigger;
    public Text pondDialogContinueMessage;
    public string pondDialogContinueMessageWords;
    private string pondDialog2ContinueMessageWords;
    public bool Dialog2;
    // Start is called before the first frame update
    void Start()
    {
        PlayerVariables = PlayerObject.GetComponent<PlayerController>();
        playerInPond = false;
        Dialog2 = false;
        pondDialog2ContinueMessageWords = "press space";
        pondDialog2Words = "You wade deeper into the water, which now rises up to your waist. You reach in to the filth, and your hand returns grasping a key. It is rusted beyond belief, and covered in pond scum.";
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInPond == true && Input.GetKeyDown(KeyCode.E) && Dialog2 == false) {
            textBox.SetActive(false);
            Dialog2 = true;
        }
        if(Dialog2 == true) {
            PlayerVariables.transform.position = new Vector2(7.5f, -5.67f);
            pondDialog.text = pondDialog2Words;
            pondDialogContinueMessage.text = pondDialog2ContinueMessageWords;
            textBox.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) {
                textBox.SetActive(false);
                PlayerVariables.playerMovementStop = false;
                PlayerVariables.playerNoAttack = false;
                PlayerVariables.playerHasKey = true;
                Destroy(pondDialogTrigger);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            pondDialog.text = pondDialogWords;
            pondDialogContinueMessage.text = pondDialogContinueMessageWords;
            textBox.SetActive(true);
            playerInPond = true;
            PlayerVariables.playerMovementStop = true;
        }
    }
}
