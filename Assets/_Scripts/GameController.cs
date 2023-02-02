using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] private bool isPause = false;
    [SerializeField] private Canvas startScreen;
    [SerializeField] private Canvas loseScreen;
    [SerializeField] private PlayerController playerController;
    
    



    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        LoseScreen();
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        startScreen.gameObject.SetActive(false);
    }

    public void TimeControl()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
    
    private void LoseScreen()
    {
        int lenght = playerController.players.Count;
        
        if (lenght == 0)
        {
            loseScreen.gameObject.SetActive(true);
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
