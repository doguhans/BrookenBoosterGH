using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    AudioSource aS;
    bool toggleMode= true;
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.M))
        {
            toggleMode = !toggleMode;
        }
        if(toggleMode)
        {
            aS.enabled = true;
        }
        else if (! toggleMode)
        {
            aS.enabled = false;
        }
       
    }
}
