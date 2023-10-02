using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrbBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameManager.is2Jumpable = true;
            gameObject.SetActive(false);
            Invoke("ResetOrb",3);
        }
    }

    void ResetOrb() {
        gameObject.SetActive(true);
    }
}
