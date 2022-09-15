using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public bool moveUp;
    public bool moveDown;
    public bool moveLeft;
    public bool moveRight;
    public bool playerMovementStop;
    public Vector2 playerPosition;
    
    // Start is called at the beginning of the game, before the first frame update
    void Start()
    {
        moveUp = true;
        moveDown = true;
        moveLeft = true;
        moveRight = true;
        playerMovementStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;
        if(playerMovementStop == false) {
            if(Input.GetKeyDown(KeyCode.W)) {
                if(moveUp == true) {
                    if(playerPosition.y <= 3.5) {
                        transform.Translate(0f, 1f, 0f); }}
            }
            else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                if(moveDown == true) {
                    transform.Translate(0f, -1f, 0f); }
            } 
            else if(Input.GetKeyDown(KeyCode.D)) {
                if(moveRight == true) {
                    transform.Translate(1f, 0f, 0f); }
            } 
            else if(Input.GetKeyDown(KeyCode.A)) {
                if(moveLeft == true) {
                    transform.Translate(-1f, 0f, 0f); }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("upBlocked")) {
            moveUp = false;
        } else if(other.CompareTag("downBlocked")) {
            moveDown = false;
        } else if(other.CompareTag("leftBlocked")) {
            moveLeft = false;
        } else if(other.CompareTag("rightBlocked")) {
            moveRight = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("upBlocked")) {
            moveUp = true;
        } else if(other.CompareTag("downBlocked")) {
            moveDown = true;
        } else if(other.CompareTag("leftBlocked")) {
            moveLeft = true;
        } else if(other.CompareTag("rightBlocked")) {
            moveRight = true;
        }
    }
}
