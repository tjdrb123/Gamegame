using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private List<GameObject> spawnObjects;


    private void Awake()
    {
        spawnObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("SpawnPostion"));
    }

    private void Start()
    {
        StartCoroutine(SpawnStart());
    }

    private IEnumerator SpawnStart()
    {
        while(true)
        {
            SpawnObject();
            yield return new WaitForSeconds(5);
        }
    }

    private void SpawnObject()
    {
        Debug.Log(spawnObjects.Count);
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            GameObject spawnLocation = spawnObjects[i];
            GameObject spawnedObject = ObjectPool.Instance.SpawnFromPool("Enemy");

            spawnedObject.transform.position = spawnLocation.transform.position;
            spawnedObject.SetActive(true);
        }
    }
}
