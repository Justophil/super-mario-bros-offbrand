using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicMovement : MonoBehaviour
{
    public int methodIndex;
    private string methodName;

    // Start is called before the first frame update
    void Start()
    {
        string[] list = {"Transform","Rotate"};
        methodName = list[methodIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(methodName, 0.0f);
    }
    void Transform() {
        
    }
    void Rotate() {
        
    }
}
