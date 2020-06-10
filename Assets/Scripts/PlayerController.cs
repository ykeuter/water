using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 25;
    [SerializeField] float speed = 30;
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
            transform.Rotate(Vector3.right, Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed);

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
            Destroy(other);
            gameManager.Powerup();
        }
    }
}
