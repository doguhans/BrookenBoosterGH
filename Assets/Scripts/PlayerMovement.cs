using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//update...
public class PlayerMovement : MonoBehaviour
{   
   // Transform x = gameObject<Transform>().translate;
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal")* Time.deltaTime;
        float zValue = Input.GetAxis("Vertical")*  Time.deltaTime;

        //her frame de(zaman kesitinde) x y z değerleri kadar yer değiştiriyor

        transform.Translate( xValue, zValue, 0);
    }
}

// EXAMPLE SCRIPT FROM LAST PROJECT




/* void Update()
{
    float xVal = Input.GetAxis("Horizontal")* Time.deltaTime * movementSpeed;

    transform.Translate(xVal, yVal, 0);...
}*/