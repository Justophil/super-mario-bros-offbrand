using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointBehavior : MonoBehaviour
{
    void Update() {
        GameManager.PrintScore();
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameManager.LoadLevel(1);
        }    
    }
}
