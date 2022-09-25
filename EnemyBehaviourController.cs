using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourController : MonoBehaviour
{
    //Integer called DemonHealth. This is used to measure the remaining health points of the player's enemy. If this reaches 0, the enemy is destroyed (removed from the game environment).
    public int DemonHealth;
    //GameObject called Demon. This is used to reference the object that this script is attatched to, the enemy character.
    public GameObject Demon;
    //GameObjeect called PlayerObject. This is used to reference to the Player object to get access to the PlayerController script.
    public GameObject PlayerObject;
    //A reference to another class called PlayerController. This is used to access and modify the variables in that class.
    private PlayerController PlayerVariables;
    //GameObject called demonAttackPrefab used to reference the prefab object that is used for the enemy's attacks. This object is cloned when the demon attacks.
    public GameObject demonAttackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PlayerVariables = PlayerObject.GetComponent<PlayerController>();
        DemonHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(DemonHealth == 0) {
            Destroy(Demon);
        }
        if(PlayerVariables.playerTurn == false) {
            GameObject demonAttackTemp = Instantiate(demonAttackPrefab, PlayerVariables.transform.position, PlayerVariables.transform.rotation) as GameObject;
            //Destroy(demonAttackTemp, 0.3f);
            PlayerVariables.playerTurn = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("playerAttack")) {
            DemonHealth -= 1;
            PlayerVariables.playerTurn = false;
        }
    }
}
