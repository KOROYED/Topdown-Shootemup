using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOutOfBounds : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if(transform.position.z > 11.5f)
        {
            Destroy(gameObject);
        }
    }
}
