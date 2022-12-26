using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletParent;
    [SerializeField] private float bulletRange;
    [SerializeField] private Transform bulletExitTransfrom;
    [SerializeField] private PlayerController playerController;
    private bool isShooting = false;

    public float spawnSpeed;

    private void Update()
    {
        StartShooting();
    }


    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / spawnSpeed);
            
            Destroy(Instantiate(bullet, bulletExitTransfrom.position, bullet.transform.rotation, bulletParent.transform), bulletRange);
        }
    }

    private void StartShooting()
    {
        if (playerController.isActive && !isShooting)
        {
            StartCoroutine(Spawner());
            isShooting = true;
        }
    }
}
