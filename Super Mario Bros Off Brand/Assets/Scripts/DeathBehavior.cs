using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameManager.LoadLevel();
        }
    }
}
