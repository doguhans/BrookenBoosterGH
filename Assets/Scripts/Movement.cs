using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{

    //float xVal= 0f, yVal = 0f ;

    [SerializeField] float rForce = 100f;
    [SerializeField] float tForce = 1000f;
    
    Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       /* rb.constraints = RigidbodyConstraints.FreezeRotationX;

        rb.constraints= RigidbodyConstraints.FreezeRotationY;   başarısız deneme

        rb.constraints= RigidbodyConstraints.FreezePositionZ; */
       

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        
    }

    void ProcessThrust()
    {
        float timedependentthrust = tForce*Time.deltaTime; // frame independent since multiplied by Time.deltaTime

        if(Input.GetKey(KeyCode.Space)) // ...GetKey("up")
        {

            rb.AddRelativeForce(0, timedependentthrust, 0); // ...AddRelativeForce(vector3.up);

           /* Debug.Log("you pressed up.");
            xVal  = Input.GetAxis("Vertical") * Time.deltaTime* tForce;     // knowledge from past
            transform.Translate(0, xVal, 0); */
        }
    }
        
        void ProcessRotation()
        {
            float timedependentrotation = rForce*Time.deltaTime;  // frame independent since multiplied by Time.deltaTime

            if(Input.GetKey("left") || Input.GetKey(KeyCode.A)) // ...GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(timedependentrotation); // transform.Rotate(0,0,1);


            /* Debug.Log("you pressed left.");
             yVal  = Input.GetAxis("Horizontal") * Time.deltaTime* rForce;  // knowledge from past
             transform.Rotate(0, 0, -yVal);*/


        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
        {
          
          ApplyRotation(-timedependentrotation);  //transform.Rotate(0,0,-1* timedependentrotation); // transform.Rotate(backward);


          /*  Debug.Log("you pressed right.");
            yVal  = Input.GetAxis("Horizontal") * Time.deltaTime* rForce;  // knowledge from past
            transform.Rotate(0, 0, yVal);*/
        }
        }

         void ApplyRotation(float tdependentrotation)
        {   
            rb.freezeRotation= true;    // freezing rotation so we can manually rotate     THIS IS FOR BUGGY ROTATION SITUATION WHEN COLLISION APPLIED BETWEEN ROCKET AND OBSTACLE
            transform.Rotate(Vector3.forward * tdependentrotation);
            rb.freezeRotation= false;  // unfreezing rotation so the physics system can take over
        }

}


