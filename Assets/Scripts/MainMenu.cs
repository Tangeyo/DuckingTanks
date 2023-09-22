using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update()
    {
        // Check if any key has been pressed to start the game
        if (Input.anyKeyDown)
        {
            PlayGameKey();
        }
    }

    public void PlayGameKey() 
    {
     SceneManager.LoadSceneAsync(1);   
    }

      public void PlayGame()
 {
    SceneManager.LoadSceneAsync(1);
 }
    
}
