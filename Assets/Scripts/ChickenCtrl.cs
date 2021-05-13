using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChickenCtrl : MonoBehaviour
{

    private Touch touch;
    private Transform tr;
    private Quaternion rotationX;
    private Quaternion rotationY;
    private float rotateSpeed = 0.1f;
    public GameObject foodObj;
    private float initialDistance;
    private Vector3 initialScale;


    void Start()
    {
        foodObj.transform.rotation = Quaternion.identity;
       
    }   

    
    void Update()
    { 

        if (Input.touchCount == 2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if (touchZero.phase ==TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled ||
                touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
                {
                    return;
                }

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                //initialScale = foodObj.transform.localScale;
            }

            else
            {
                var currentDistance = Vector2.Distance(touchZero.position, touch.position);
                
                if(Mathf.Approximately(initialDistance, 0))
                {
                    return;
                }

                var factor = currentDistance / initialDistance;
                foodObj.transform.localScale = initialScale * factor;
            }

        }

    

    
        if (Input.touchCount == 1)
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
