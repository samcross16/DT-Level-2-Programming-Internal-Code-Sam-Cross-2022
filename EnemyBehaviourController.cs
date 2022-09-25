using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourController : MonoBehaviour
{
    public int DemonHealth;
    public GameObject Demon;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(DemonHealth == 0) {
            Debug.Log("Demon Vanquished.");
            Destroy(Demon);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("playerAttack")) {
            DemonHealth -= 1;
            Debug.Log("You hit the demon for 1 damage!");
        }
    }
}
