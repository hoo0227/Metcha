using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BibimCtrl : MonoBehaviour
{

    private Touch touch;
    private Transform tr;
    private Quaternion rotationX;
    private Quaternion rotationY;
    private float rotateSpeed = 0.1f;
    public GameObject foodObj;
    private float initialDistance;
    private Vector3 initialScale;
    private float Min = 3.0f;
    private float Max = 6.0f;

    void Start()
    {
        
    }


    
    void Update()
    { 

        foodObj.transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, Min, Max),
                                            Mathf.Clamp(transform.localScale.y, Min, Max),
                                            Mathf.Clamp(transform.localScale.z, Min, Max));


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
                initialScale = foodObj.transform.localScale;
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