using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpawner : MonoBehaviour
{

    public static FieldSpawner SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;

    private void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {

        //Ensures that the seed isn't likely to be the same number consecutively 
        Random.InitState(System.DateTime.Now.Millisecond);

        pooledObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < amountToPool; i++)
        {
            //Positions the objects randomly within a rectangle
            Vector3 rectangle = new Vector3(Random.Range(-230F, 300F), Random.Range(-240f, 240f), 0);
            temp = Instantiate(objectToPool[Random.Range(0, 3)], rectangle, Random.rotation);
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }
    }

    public GameObject GetObject()
    {

        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }


}
