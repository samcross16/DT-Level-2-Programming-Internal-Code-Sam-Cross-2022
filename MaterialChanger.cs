using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public bool magicShield = false;
    public GameObject magicParticleEffect;
    
    void Start() {
    }
    


    // Update is called once per frame
    void Update()
    {
        if(transform.position == new Vector3(-8.5f, 4.5f, 0f)) {
            magicShield = true;
        } else {
            magicShield = false;
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("MagicAttack")) {
            StartCoroutine(magicShieldEffect());
        }
    }

    IEnumerator magicShieldEffect() {
        while(true) {
            GameObject MagicPrtclTemp = Instantiate(magicParticleEffect, transform.position, transform.rotation) as GameObject;
            yield return new WaitForSeconds(0.5f);
            Destroy(MagicPrtclTemp);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
