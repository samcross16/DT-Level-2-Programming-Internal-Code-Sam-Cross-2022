using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    
    //variable which determines which level is to be loaded. This will be decided 
    public string sLevelToLoad;

    //Performs function when a trigger is entered, this trigger is the collider in the game object this script is bound to.
    private void OnTriggerEnter2D(Collider2D collision) {
        //Reads all information about the game object collided with.
        GameObject collisionGameObject = collision.gameObject;
        //checks if the game object's name is "Player"
        if(collisionGameObject.name == "Player") {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}