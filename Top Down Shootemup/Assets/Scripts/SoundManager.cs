using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundSystem;

    public AudioClip[] popSound;
    public AudioClip enemyShootSound;
    public AudioClip playerShootSound;
    public AudioClip playerDeath;
    public AudioClip buttonClick;
    public AudioClip timeEnd;
    public AudioClip highscore;

    void Start()
    {
        soundSystem = GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    public void OnEnemyDeath()
    {
        soundSystem.PlayOneShot(popSound[Random.Range(0, 3)], 0.7f);
    }
    public void OnEnemyShoot()
    {
        soundSystem.PlayOneShot(enemyShootSound, 0.8f);
    }
    public void OnPlayerShoot()
    {
        soundSystem.PlayOneShot(playerShootSound, 0.3f);
    }
    public void OnPlayerDeath()
    {
        soundSystem.PlayOneShot(playerDeath, 0.4f);
    }
    public void OnButtonClick()
    {
        soundSystem.PlayOneShot(buttonClick, 0.5f);
    }
    public void OnTimeEnd()
    {
        soundSystem.PlayOneShot(timeEnd, 0.4f);
    }
    public void OnHighScore()
    {
        soundSystem.PlayOneShot(highscore, 0.2f);
    }
}
