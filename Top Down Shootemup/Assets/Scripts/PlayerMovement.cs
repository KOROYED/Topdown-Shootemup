using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizinralInput;
    public float verticalInput;
    public float speed = 5.0f;
    public float xRange = 17.0f;
    public float zRange = 4.0f;

    public float shootRate = 10f;
    private float nextShot = 0.0f;

    public GameObject projectilePrefab;

    void Start()
    {
        
    }


    void Update()
    {
        MovementBounds();
        PlayerMove();
        Shoot();
    }

    void MovementBounds()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange-4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange-4);
        }
        if (transform.position.z > zRange-6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange-6);
        }
    }
    void PlayerMove()
    {
        horizinralInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * horizinralInput * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextShot)
        {
            nextShot = Time.time + shootRate;
            Instantiate(projectilePrefab, new Vector3(transform.position.x,transform.position.y,transform.position.z + 0.5f), projectilePrefab.transform.rotation);
        }
    }
}
