using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowOrbBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player") {
            GameManager.IncrementScore();
            gameObject.SetActive(false);
        }
    }
}
