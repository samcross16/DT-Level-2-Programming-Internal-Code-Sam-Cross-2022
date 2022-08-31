using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Defines variable moveSpeed, which is public and is set from the unity editor (hence, no set value).
    public float moveSpeed;
    //Defines a transform, which is a 3-variable component. The variables are position (in the game world or on the screen), scale (size factor), and rotation. 
    //This transform is being used specifically for the position, and is taken from a game object which is called "playerMovePoint".
    public Transform movePoint;

    public LayerMask eventCollider;
    
    public float playerPosition;
    // Start is called at the beginning of the game, before the first frame update
    void Start()
    {
        //Sets the game object playerMovePoint to be not a child of the Player object. This unbinds it from the player's position.
        //This is very important for avoiding a bug which makes the player move around erratically.
        movePoint.parent = null;
    }


    

    // Update is called once per frame
    void Update()
    {
        //Makes the Player object that this script is controlling move from its own position, to the position of the movePoint (see line 11).
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        //Checks if the player is at the position of the movePoint. If it is then it performs the functions inside
        if(Vector3.Distance(transform.position, movePoint.position) == 0f) {
            
            //Checks if the computer is recieving input from keys that are set to horizontal movement in either direction (these keys are A, D, left, and right)
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                //Moves the movePoint in the direction of the horizontal input the computer is recieving (left or right)
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            else {
                //Checks if the computer is recieving input from keys that are set to vertical movement in either direction (these keys are W, S, up, and down)
                if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                //Moves the movePoint in the direction of the vertical input the computer is recieving (up or down)
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
            }
           
        }
    }

}
