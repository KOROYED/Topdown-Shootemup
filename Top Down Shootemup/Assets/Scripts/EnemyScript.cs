using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject bullet;
    public float fireRatep;
    public float fireRatem;
    private float nextFire;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        nextFire = Time.time + Random.Range(fireRatep, fireRatem);
    }


    void Update()
    {
        if (gameManager.isGameActive == false)
        {
            Destroy(gameObject);
        }

        int fireinterval = Random.Range(40, 60);
        if(Time.time > nextFire)
        {
            
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), bullet.transform.rotation);
            //nextFire = Time.time + Random.Range(fireRatep, fireRatem);
            nextFire += fireinterval / 2;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && gameObject.tag == "Enemy")
        {
            gameManager.AddScore(10);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
