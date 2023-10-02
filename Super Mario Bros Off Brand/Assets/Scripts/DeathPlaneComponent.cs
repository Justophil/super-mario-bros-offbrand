using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneComponent : MonoBehaviour
{   
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Debug.Log("poop");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}