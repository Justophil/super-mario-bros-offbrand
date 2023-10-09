using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrbBehavior : MonoBehaviour
{
    public ParticleSystem burst = null;
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameManager.is2Jumpable = true;
            burst.transform.position = gameObject.transform.position;
            burst.Play();
            gameObject.SetActive(false);
            Invoke("ResetOrb",30.0f);
            Invoke("Stop", 3f);
        }
    }

    void ResetOrb() {
        gameObject.SetActive(true);
    }
    void Stop() {
        burst.Stop();
    }
}
