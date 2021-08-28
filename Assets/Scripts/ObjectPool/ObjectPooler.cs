using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //Atributo para poder manipular la clase desde el editor
public class ObjectPoolItem //Clase con la que se instanciaran los game objects iniciales y en la que se iran guardando cuando sean destruidos
{
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> instancedObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        instancedObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject go = Instantiate(item.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
            }
        }
    }

    public GameObject GetPoolObject(string tag)
    {
        for (int i = 0; i < instancedObjects.Count; i++)
        {
            if (!instancedObjects[i].activeInHierarchy && instancedObjects[i].CompareTag(tag))
            {
                return instancedObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.CompareTag(tag))
            {
                GameObject go = Instantiate(item.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
                return go;
            }
        }
        return null;
    }
}