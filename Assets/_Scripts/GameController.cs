using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private bool isPause = false;
    
    public void TimeControl()
    {
        if (!isPause)
        {
            Debug.Log("dur");
            Time.timeScale = 0;
            isPause = true;
        }
        else if (isPause)
        {
            Debug.Log("durma");
            Time.timeScale = 1;
            isPause = false;
        }
    }

}
