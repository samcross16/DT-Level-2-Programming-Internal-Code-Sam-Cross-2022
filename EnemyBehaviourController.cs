using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyBehaviourController : MonoBehaviour
{
    //Integer called DemonHealth. This is used to measure the remaining health points of the player's enemy. If this reaches 0, the enemy is destroyed (removed from the game environment).
    public int DemonHealth;
    //GameObject called Demon. This is used to reference the object that this script is attatched to, the enemy character.
    public GameObject Demon;
    //GameObjeect called playerObject. This is used to reference to the Player object to get access to the PlayerController script.
    public GameObject playerObject;
    //A reference to another class called PlayerController. This is used to access and modify the variables in that class.
    private PlayerController PlayerVariables;
    //GameObject called demonAttackPrefab used to reference the prefab object that is used for the enemy's attacks. This object is cloned when the demon attacks.
    public GameObject demonAttackPrefab;

    private string Empty = " ";
    private string youDied = "You were slain. Press enter/return to return to the title menu.";
    public GameObject textBox;
    public Text textBoxText;
    public Text textBoxSmallText;
    private string gameWin;
    private string smallText;

    public string LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        PlayerVariables = playerObject.GetComponent<PlayerController>();
        DemonHealth = 50;
        smallText = "";
        gameWin = "Congratulations, you vanquished the demon! press enter/return to return to the menu screen";
        StartCoroutine(DemonTurn());
    }

    // Update is called once per frame
    void Update()
    {
        if(DemonHealth == 0) {
            Destroy(Demon);
            textBoxText.text = gameWin;
            textBoxSmallText.text = smallText;
            textBox.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene(LevelToLoad);
            }
        }

        if(PlayerVariables.PlayerHealth <= 0) {
                textBoxText.text =youDied;
                textBoxSmallText.text = Empty;
                textBox.SetActive(true);
                LevelToLoad = "MainMenu";
                playerObject.SetActive(false);
                if(Input.GetKeyDown(KeyCode.Return)) {
                    SceneManager.LoadScene(LevelToLoad);
                }
            }
    }

    //This is the Coroutine method that deals with the enemy's behaviour on their turn. This has to be used instead of a regular void method or just doing this in the Update() method as the IEnumerator coroutine can handle time, which is not possible in the Update() method.
    IEnumerator DemonTurn() {
        //First it checks for whether or not the player is non-actionable.
        if(PlayerVariables.playerTurn == false) {
            //Creates a for() loop that repeats three times. This is used to create the effect of the player being hit with three fireballs.
            for(int i = 0; i < 3; i++){
                //Creates a temporary clone of the prefab object for the enemy's attack projectile.
                GameObject demonAttackTemp = Instantiate(demonAttackPrefab, PlayerVariables.transform.position, PlayerVariables.transform.rotation) as GameObject;
                //Destroys the temporary clone after 0.4 seconds.
                Destroy(demonAttackTemp, 0.4f);
                //Reduces the player's hit points by 1 (this is done 3 times, which kills the player instantly).
                PlayerVariables.PlayerHealth--;
                //Function which waits for 0.5 seconds before the for() loop can repeat.
                yield return new WaitForSeconds(0.5f);
            }
            //Waits for an additional quarter of a second before making the player actionable again.
            yield return new WaitForSeconds(0.25f);
            PlayerVariables.playerTurn = true;
        }
        StartCoroutine(DemonTurn());
    }

    //OnTriggerEnter2D method is called when the "Enemy" gameObject detects collision from another gameObject with a collider. Other is the variable assigned to the gameObject the Enemy object has collided with.
    private void OnTriggerEnter2D(Collider2D other) {
        //Calls function if the tag of the other object is "playerAttack". This is the tag assigned to the attack prefabs genreated by th eplayer swinging their sword.
        if(other.CompareTag("playerAttack")) {
            //Reduces DemonHealth variable by 1
            DemonHealth = (DemonHealth - PlayerVariables.playerDamage);
            //Sets the playerTurn variable referenced from the PlayerController class to false.
            PlayerVariables.playerTurn = false;
        }
        //Calls this function if the other function is not called, and the tag of the other object is "playerMagic". This is the tag assignde to thee magic attack the player can get from the old man.
        else if(other.CompareTag("MagicAttack")) {
            //Sets DemonHealth variable equal to 0
            DemonHealth = 0;
            //Sets the playerTurn variable referenced from the PlayerController class to false.
            PlayerVariables.playerTurn = false;
        }
    }
    //
}
