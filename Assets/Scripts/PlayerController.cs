﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 75;
    [SerializeField] float verticalSpeed = 25;
    [SerializeField] float speed = 25;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed);

            transform.position += transform.up * Input.GetAxis("Vertical") * Time.deltaTime * verticalSpeed;

            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        else
        {
            Destroy(other.gameObject);
            gameManager.Powerup();
        }
    }
}
