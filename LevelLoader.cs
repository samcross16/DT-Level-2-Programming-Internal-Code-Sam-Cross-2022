using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    
    //variable which determines which level is to be loaded.
    public string LevelToLoad;

    //Update method is called once per frame.
    void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}