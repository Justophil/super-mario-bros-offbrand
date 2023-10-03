using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameManager.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }    
    }
}
