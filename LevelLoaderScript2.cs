using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript2 : MonoBehaviour
{
    public string LevelToLoad;

    void Update() {
        if(Input.GetKeyDown(KeyCode.V)) {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
