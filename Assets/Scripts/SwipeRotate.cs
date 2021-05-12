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
    private Vector3 originalPos;
 
    void Start()
        {
            originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        //alternatively, just: originalPos = gameObject.transform.position;
        
        }
    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "End")
            {
                gameObject.transform.position = originalPos;
            }
            
        }
    

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotationX = Quaternion.Euler(touch.deltaPosition.y * rotateSpeed, 0f, 0f);

                transform.rotation = rotationX * transform.rotation;
            }

        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotateSpeed,  0f);

                transform.rotation = rotationY * transform.rotation;
            }

        }

        
    }
}
