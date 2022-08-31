using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<List<GameObject>> pooledObjects;
    public List<GameObject> objectToPoolOne;
    public List<int> objectQuantity;
    //public GameObject objectToPoolTwo;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<List<GameObject>>();
        for (int i = 0; i < objectQuantity.Count; i++)
        {
            pooledObjects.Add(new List<GameObject>());
        }
        for (int i = 0; i < objectQuantity.Count; i++)
        {
            for (int j = 0; j < objectQuantity[i]; j++)
            {
                GameObject objOne = (GameObject)Instantiate(objectToPoolOne[i]);
                objOne.SetActive(false);
                pooledObjects[i].Add(objOne);
                objOne.transform.SetParent(this.transform);
            }
            
        }
    }

    public GameObject GetPooledObjects(int bulletType)
    {
        for (int i = 0; i < pooledObjects[bulletType].Count; i++)
        {
            if (!pooledObjects[bulletType][i].activeInHierarchy)
            {
                return pooledObjects[bulletType][i];
            }
        }
        return null;
    }
}
