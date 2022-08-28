using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private GameManager gameManager;
    private SoundManager soundManager;

    void Start()
    {

        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet" && gameObject.tag == "Player")
        {
            if(gameManager.score > PlayerPrefs.GetInt("HighScore", 0))
            {
                soundManager.OnHighScore();
            }
            else
            {
                soundManager.OnPlayerDeath();
            }
            gameManager.GameOver();
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }
}
