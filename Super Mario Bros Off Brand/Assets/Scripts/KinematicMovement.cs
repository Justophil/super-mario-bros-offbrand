using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicMovement : MonoBehaviour
{
    public bool spin;
    public bool move;
    float timer = 0;
    public float spinSpeed;
    public float moveSpeed;

    Vector3 movement = new Vector3(0, 1, 0);

    // Update is called once per frame
    void Update()
    {
        if(move) {
            Invoke("Transform", 0.0f);
        }
        if(spin) {
            Invoke("Rotate", 0.0f);
        }
    }
    void Transform() {
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            timer = 0f;
            movement = -1 * movement;
        }
        transform.Translate(movement * moveSpeed *  Time.deltaTime);
    }
    void Rotate() {
        transform.Rotate(movement * spinSpeed * Time.deltaTime, Space.Self);
    }
}
