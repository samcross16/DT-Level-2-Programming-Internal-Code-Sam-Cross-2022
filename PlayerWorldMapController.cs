using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWorldMapController : MonoBehaviour
{
    //Start method is called before first call of Update() method
    void Start() {
        
    }

    // Update method is called once per frame update
    void Update()
    {
        //Movement system. Detects if the required key is pressed. If it is, translates Player object one unit in the associated direction (W=up, A=left, S=down, D=right).
        //else if() statements prevent movement in multiple directions simultaneously.
        if(Input.GetKeyDown(KeyCode.W) && transform.position.y <= 3.5) {
                transform.Translate(0f, 1f, 0f);
            } else if(Input.GetKeyDown(KeyCode.A) && transform.position.x >= -8) {
                        transform.Translate(-1f, 0f, 0f);
            } else if(Input.GetKeyDown(KeyCode.S) && transform.position.y >= -5) {
                        transform.Translate(0f, -1f, 0f);
            } else if(Input.GetKeyDown(KeyCode.D) && transform.position.x <= 8) {
                        transform.Translate(1f, 0f, 0f);
            }

        //Sends the player to the next screen of the game if they're within the correct range of spaces on the map.
        if(transform.position == new Vector3(2.45f, 2.45f, 0f) && Input.GetKeyDown(KeyCode.M)) {
            SceneManager.LoadScene("RuinScene");
        }
        else if(transform.position == new Vector3(3.45f, 2.45f, 0f) && Input.GetKeyDown(KeyCode.M)) {
            Debug.Log("TownScene");
        }
    }
}
