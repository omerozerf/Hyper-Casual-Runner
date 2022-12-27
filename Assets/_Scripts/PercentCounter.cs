using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PercentCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text percentText;
     private PlayerController playerController;
    

    public float counter = 0;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (counter >= 100)
        {
            playerController.isShot = true;
                            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (counter < 80)
            {
                counter += Random.Range(5f, 20f);
                percentText.text = "%"+counter.ToString("00.00");
            }
            else
            {
                counter += 100 - counter;
                percentText.text = "%"+counter.ToString("00.00");
            }
            
        }
    }
}
