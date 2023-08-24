using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  //GameObject ggameObject;
  float loadSceneTime = 2f;
  [SerializeField] AudioClip death;
  [SerializeField] AudioClip finish;

  [SerializeField] ParticleSystem deathParticles;
  [SerializeField] ParticleSystem finishParticles;

  AudioSource aS;
  BoxCollider boxCollider;


  bool isTransitioning = false;
  bool collisionCheatActive = false;
  void Start()
  {
    aS = GetComponent<AudioSource>();
    boxCollider = GetComponent<BoxCollider>();
  }

  void Update()
  {
    CheatCodes();

  }

  void OnCollisionEnter(Collision other)
  {

    if (isTransitioning || collisionCheatActive)
    {
      return;
    }
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
        OnCollisionWithFuel(other);
        Debug.Log("You added fuel.");
        break;
      default:
        Debug.Log("Lul.");
        CrashScenario();
        break;
    }
  }

  void FinishingScenario()
  {
    isTransitioning = true;
    aS.Stop();
    aS.PlayOneShot(finish);
    finishParticles.Play();
    GetComponent<Movement>().enabled = false;
    Invoke("LoadNextLevel", loadSceneTime);
  }
  void CrashScenario()
  {
    isTransitioning = true;
    GetComponent<Movement>().enabled = false;
    aS.Stop();
    aS.PlayOneShot(death);
    deathParticles.Play();
    Invoke("ReloadLevel", loadSceneTime);
  }

  void ReloadLevel()
  {
    int initialLevel = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(initialLevel);
  }

  void LoadNextLevel()
  {

    int initialLevelIndex = SceneManager.GetActiveScene().buildIndex;
    int nextLevelIndex = initialLevelIndex + 1;
    if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
    {
      nextLevelIndex = 0;
    }
    SceneManager.LoadScene(nextLevelIndex);
  }

  void OnCollisionWithFuel(Collision other)
  {
    Destroy(other.gameObject);
  }

  void CheatCodes()
  {
    
    if (Input.GetKey(KeyCode.L))
    {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      int nextScene = currentSceneIndex + 1;
      if (nextScene == SceneManager.sceneCountInBuildSettings)

        SceneManager.LoadScene(0);
      else
      {
        SceneManager.LoadScene(nextScene);
      }
    }
    if (Input.GetKeyDown(KeyCode.C))
    {
      collisionCheatActive = !collisionCheatActive;
      
      if(collisionCheatActive)
      Debug.Log("Activating Cheats.");
      else if(!collisionCheatActive)
      Debug.Log("Cheats Deactivated.");
    

    }

  }

}
