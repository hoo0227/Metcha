using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotate : MonoBehaviour
{

    private Touch touch;
    private Vector3 touchPosition;
    private Quaternion rotationX;
    private Quaternion rotationY;
    private float rotateSpeed = 0.1f;
   
    void Start()
        {
           
        
        }
  
    

    void Update()
    {
        if (Input.touchCount > 0)
        {
           
           if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotateSpeed,  0f);

                transform.rotation = rotationY * transform.rotation;
            }
        }

       
           
           

    

      

        
    }
}
