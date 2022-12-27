using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (isActive)
        {
            MoveStraight();
            MoveHorizontal();
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
        if (other.CompareTag("Greenzone") || other.CompareTag("Redzone"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Bullet"))
        {
            renderer.material.color = color;
        }

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
            var position = new Vector3(position1.x - Random.Range(-1f, 1f), 0, position1.z - 0.5f);
            players.Add(p);
            collision.gameObject.transform.position = position;
            p.animator.Play("Pistol Run");
        }

        if (collision.gameObject.TryGetComponent(out PlayerController playerController) && !playerController.isShot && isMainPlayer)
        {
            
            playerController.animator.Play("Standing Death Left 02");
            players[^1].animator.Play("Standing Death Left 02");
            Destroy(players[^1].gameObject, 2f);
            players.RemoveAt(players.Count-1);
        }
    }
}
