using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowOrbBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem burst = null;
    
    void OnTriggerEnter(Collider other){
        if(other.tag == "Player") {
            GameManager.IncrementScore();
            GameManager.PrintScore();
            burst.transform.position = gameObject.transform.position;
            burst.Play();
            Destroy(gameObject);
            Invoke("Stop", 3f);
        }
    }
    void Stop() {
        burst.Stop();
    }
}
