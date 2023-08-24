using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
     void Update() {
        
        QuitApp();
        
      }

      void QuitApp()
      {
          if(Input.GetKeyDown(KeyCode.Escape))
          {
            Debug.Log("You have pressed Escape Button");
            Application.Quit();
          }
      }
    
}
