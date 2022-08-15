using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject bullet;
    public float fireRatep;
    public float fireRatem;
    private float nextFire = 3.0f;

    void Start()
    {
        nextFire = Time.time + Random.Range(fireRatep, fireRatem);
    }


    void Update()
    {
        int fireinterval = Random.Range(20, 60);
        if(Time.time > nextFire)
        {
            
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), bullet.transform.rotation);
            //nextFire = Time.time + Random.Range(fireRatep, fireRatem);
            nextFire += fireinterval / 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
