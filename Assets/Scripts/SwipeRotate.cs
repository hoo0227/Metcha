using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotate : MonoBehaviour
{

    private Touch touch;
    public Quaternion startRot;
    private Transform tr;
    private Quaternion rotationX;
    private Quaternion rotationY;
    private float rotateSpeed = 0.1f;


    void Awake()
    {
        startRot = transform.rotation;
    }
    
    void Update()
    { 
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
           
            if (touch.phase == TouchPhase.Moved)
            {
                rotationX = Quaternion.Euler(touch.deltaPosition.y * rotateSpeed, 0f,  0f);
              
                transform.rotation = rotationX * transform.rotation;

        
              
            }
                
        }

       
    }
}
