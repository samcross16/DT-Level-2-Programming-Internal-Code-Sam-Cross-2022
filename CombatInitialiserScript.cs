using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatInitialiserScript : MonoBehaviour
{
    
    public int playerMovesRemaining;
    public GameObject PlayerObject;
    private PlayerController PlayerVariables;
    public GameObject dialogueBox;
    private string enemyDialogueMessage;
    public Text enemyDialogueTextObject;
    private bool dialogueBoxIsActive;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        PlayerVariables = PlayerObject.GetComponent<PlayerController>();
        enemyDialogueMessage = "Demon: Who dare disturbeth me? I may be bound to this place, but I will still kill you where you stand! (press the arrow keys to attack)";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && dialogueBoxIsActive == true) {
            dialogueBox.SetActive(false);
            PlayerVariables.playerMovementStop = false;
            PlayerVariables.playerTurn = true;
            PlayerVariables.playerInCombat = true;
            PlayerVariables.playerNoAttack = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            enemyDialogueTextObject.text = enemyDialogueMessage;
            dialogueBox.SetActive(true);
            dialogueBoxIsActive = true;
            PlayerVariables.playerMovementStop = true;
            PlayerVariables.playerNoAttack = true;
            Enemy.SetActive(true);
        }
    }
}
