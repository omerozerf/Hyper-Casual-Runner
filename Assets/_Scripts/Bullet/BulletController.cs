using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        MoveStraight();
    }

    private void MoveStraight()
    {
        transform.Translate(Vector3.up * (bulletSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController) && other.TryGetComponent(out PercentCounter percentCounter))
        {
            gameObject.SetActive(false);
            
            if (percentCounter.counter == 100)
            {
                playerController.isShot = true;
                            
            }
        }
    }
}
