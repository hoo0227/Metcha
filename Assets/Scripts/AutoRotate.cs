using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float degreePerSeconds = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float speed = degreePerSeconds * Time.deltaTime;
        transform.Rotate(Vector3.up * speed);
    }
}
