using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
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
