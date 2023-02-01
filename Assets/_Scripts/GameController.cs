using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private bool isPause = false;
    
    private void Update()
    {
        PauseGame();
        ResumeGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
    }

    private void ResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
}
