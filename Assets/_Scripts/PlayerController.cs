using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] public bool isActive;
    [SerializeField] public bool isShot;
    [SerializeField] private new Renderer renderer;
    [SerializeField] private Color color;
    [SerializeField] private Transform mainTransform;
    [SerializeField] private PlayerController mainPlayer;
    [SerializeField] private bool isMainPlayer = false;
    [SerializeField] private BulletSpawner bulletSpawner;
    [SerializeField] private Canvas canvas;
    [SerializeField] private PercentCounter percentCounter;
    
    

    [SerializeField] private Animator animator;




    public List<PlayerController> players = new List<PlayerController>();

    private void Start()
    {
        if (isMainPlayer)
        {
            players.Add(mainPlayer);
            animator.Play("Pistol Run");
        }
        
    }

    private void Update()
    {
        WinAnimation();
        if (isActive)
        {
            MoveStraight();
            MoveHorizontal();
        }
        
        if (isShot)
        {
            renderer.material.color = color;
        }
    }

    private void WinAnimation()
    {
        if (transform.position.z > 282)
        {
            animator.Play("Victory");
            isActive = false;
        }
    }

    private void MoveHorizontal()
    {
        var joystickInput = joystick.Horizontal;
        transform.Translate(Vector3.right * (joystickInput * moveSpeed * Time.deltaTime));
    }

    private void MoveStraight()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Greenzone") || other.CompareTag("Redzone"))
        {
            other.gameObject.SetActive(false);
        }
        */
        

        if (other.CompareTag("Greenzone"))
        {
            bulletSpawner.spawnSpeed += bulletSpawner.spawnSpeed / 3;
        }
        if (other.CompareTag("Redzone"))
        {
            bulletSpawner.spawnSpeed -= bulletSpawner.spawnSpeed / 3;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController p) && p.isShot && isMainPlayer)
        {
            p.isActive = true;
            var position1 = players[^1].transform.position;
            var position = new Vector3(position1.x - Random.Range(-2f, 2f), 0, position1.z - 1f);
            players.Add(p);
            collision.gameObject.transform.position = position;
            p.animator.Play("Pistol Run");
            p.canvas.gameObject.SetActive(false);
        }

        if (collision.gameObject.TryGetComponent(out PlayerController playerController) && !playerController.isShot && isMainPlayer)
        {
            
            playerController.animator.Play("Standing Death Left 02");
            playerController.isActive = false;
            players[^1].animator.Play("Standing Death Left 02");
            players[^1].isActive = false;
            Destroy(players[^1].gameObject, 2f);
            players.RemoveAt(players.Count-1);
        }
    }

    /*private Position CreateArmy()
    {
        int lineCounter = 0;

        if (lineCounter == 0)
        {
            lineCounter++;
            
        }

        if (lineCounter == 1)
        {
            lineCounter++;
        }

        if (lineCounter == 3)
        {
            lineCounter++;
        }
    }*/
}
