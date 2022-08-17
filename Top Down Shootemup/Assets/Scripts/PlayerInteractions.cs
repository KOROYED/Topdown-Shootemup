using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet" && gameObject.tag == "Player")
        {
            gameManager.GameOver();
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
