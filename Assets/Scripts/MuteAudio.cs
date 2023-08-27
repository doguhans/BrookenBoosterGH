using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{
    AudioSource aS;
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Game Muted.");
            aS.enabled = false;
        }
       
    }
}
