using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamestartscript : MonoBehaviour
{
    public string LevelToLoad;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
