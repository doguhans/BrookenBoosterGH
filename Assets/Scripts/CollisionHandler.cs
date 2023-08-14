using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
   // GameObject ggameObject;

     
    void OnCollisionEnter(Collision other) {
        
        switch (other.gameObject.tag) 
        {
          case "Friendly":
          Debug.Log("You are at starting zone.");
          break;
          case "Finish":
          Debug.Log("You are at End zone.");
          LoadNextLevel();
          break;
          case "Fuel":
          Debug.Log("You added fuel.");
          break;
          default:  
          Debug.Log("Lul.");
          ReloadLevel();
          break ;
        }
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
      if(initialLevelIndex <= SceneManager.sceneCount-1)
      {
      SceneManager.LoadScene(nextLevelIndex);
      }
      else
      {
        SceneManager.LoadScene(0);
      }
    }
}
