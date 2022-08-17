using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOutOfBounds : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    void Update()
    {
        if(transform.position.z > 11.5f)
        {
            gameManager.AddScore(-10);
            Destroy(gameObject);
        }
        if (transform.position.z < -11f)
        {
            Destroy(gameObject);
        }
    }
}
