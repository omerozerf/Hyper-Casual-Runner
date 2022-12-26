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
    
    

    public List<PlayerController> players = new List<PlayerController>();

    private void Start()
    {
        players.Add(mainPlayer);
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController p) && p.isShot && isMainPlayer)
        {
            p.isActive = true;
            var position1 = players[^1].transform.position;
            var position = new Vector3(position1.x - Random.Range(-3f, 3f), 0, position1.z - 2);
            players.Add(p);
            collision.gameObject.transform.position = position;
        }
    }
}
