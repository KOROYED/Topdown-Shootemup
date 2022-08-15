using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet" && gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
