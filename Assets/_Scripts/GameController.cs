using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private bool isPause = false;
    [SerializeField] private Canvas startScreen;
    

    private void Start()
    {
        Time.timeScale = 0;
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

}
