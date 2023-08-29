using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{

    //float xVal= 0f, yVal = 0f ;

    [SerializeField] float rForce = 100f;
    [SerializeField] float tForce = 1000f;
    [SerializeField] AudioClip mainEngine;


    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem sideBooster_L;
    [SerializeField] ParticleSystem sideBooster_R;
    Rigidbody rb;
    AudioSource aS;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aS = GetComponent<AudioSource>();


     


    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        rb.freezeRotation = true; // will remove this after some point...
    }

    void ProcessThrust()
    {
        float timedependentthrust = tForce * Time.deltaTime; // frame independent since multiplied by Time.deltaTime

        if (Input.GetKey(KeyCode.Space)) // ...GetKey("up")
        {
            if (!mainEngineParticle.isPlaying)
                mainEngineParticle.Play();

            rb.AddRelativeForce(0, timedependentthrust, 0); // ...AddRelativeForce(vector3.up);

            if (!aS.isPlaying)
            {
                aS.PlayOneShot(mainEngine);
            }
            /* Debug.Log("you pressed up.");
              xVal  = Input.GetAxis("Vertical") * Time.deltaTime* tForce;     // knowledge from past
              transform.Translate(0, xVal, 0); */
        }

        else
        {
            aS.Stop();
            mainEngineParticle.Stop();
        }
    }

    void ProcessRotation()
    {
        float timedependentrotation = rForce * Time.deltaTime;  // frame independent since multiplied by Time.deltaTime


        if (Input.GetKey("left") || Input.GetKey(KeyCode.A)) // ...GetKey(KeyCode.LeftArrow))
        {

            ApplyRotation(timedependentrotation); // transform.Rotate(0,0,1);
            if (!sideBooster_R.isPlaying)
            {
                sideBooster_R.Play();
            }
            /* Debug.Log("you pressed left.");
             yVal  = Input.GetAxis("Horizontal") * Time.deltaTime* rForce;  // knowledge from past
             transform.Rotate(0, 0, -yVal);*/
        }
        else
        {

            sideBooster_R.Stop();
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            ApplyRotation(-timedependentrotation);  //transform.Rotate(0,0,-1* timedependentrotation); // transform.Rotate(backward);
            if (!sideBooster_L.isPlaying)
            { sideBooster_L.Play(); }

            /*  Debug.Log("you pressed right.");
              yVal  = Input.GetAxis("Horizontal") * Time.deltaTime* rForce;  // knowledge from past
              transform.Rotate(0, 0, yVal);*/
        }
        else
        {

            sideBooster_L.Stop();
        }
    }

    void ApplyRotation(float tDependentRotation)
    {
        rb.freezeRotation = true;    // freezing rotation so we can manually rotate     THIS IS FOR BUGGY ROTATION SITUATION WHEN COLLISION APPLIED BETWEEN ROCKET AND OBSTACLE
        transform.Rotate(Vector3.forward * tDependentRotation);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }



}


