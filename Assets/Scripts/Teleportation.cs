using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject objToTeleport;
   void TeleportingSequenceOnTop()
    {
        Vector3 playerPosVec = player.transform.position;
        Vector3 objPosVec = objToTeleport.transform.position;
        Vector3 transformValue = objPosVec - playerPosVec;
        transformValue.y += 5f;
        player.transform.position += transformValue;
    }
   private void OnCollisionEnter(Collision other) {
    
    switch (other.gameObject.tag)   
    {
        case"Player":
        Debug.Log("Teleporting...");
        Invoke("TeleportingSequenceOnTop",.5f);        
        break;
        default:        
        break;


    }

   }
}
