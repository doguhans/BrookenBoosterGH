using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //GameObject ggameObject;
    float loadSceneTime = 2f;
     
    void OnCollisionEnter(Collision other) {
        
        switch (other.gameObject.tag) 
        {
          case "Friendly":
          Debug.Log("You are at starting zone.");
          break;
          case "Finish":          
          Debug.Log("You are at Finishing Zone.");
          FinishingScenario();
          break;
          case "Fuel":
          OnCollisionWithFuel( other );
          Debug.Log("You added fuel.");
          break;
          default:  
          Debug.Log("Lul.");
          CrashScenario();
          break ;
        }
    }

   void FinishingScenario()
   {
      GetComponent<Movement>().enabled = false;
      Invoke("LoadNextLevel",loadSceneTime );
   }
    void CrashScenario()
    {
      GetComponent<Movement>().enabled = false;
      Invoke("ReloadLevel",loadSceneTime);
    }

    void ReloadLevel()
    {
      int initialLevel = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(initialLevel);
    }

    void LoadNextLevel()
    {
      
      int initialLevelIndex =SceneManager.GetActiveScene().buildIndex;
      int nextLevelIndex = initialLevelIndex + 1 ;
      if(nextLevelIndex == SceneManager.sceneCountInBuildSettings)
      {
      nextLevelIndex = 0;
      }
      SceneManager.LoadScene(nextLevelIndex);
    }

     void OnCollisionWithFuel(Collision other)
    {
      other.gameObject.GetComponent<MeshRenderer>().enabled = false ;
      other.gameObject.GetComponent<SphereCollider>().enabled = false;
    }

}
