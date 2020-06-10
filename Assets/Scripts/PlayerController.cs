using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
        transform.Rotate(Vector3.right, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}
