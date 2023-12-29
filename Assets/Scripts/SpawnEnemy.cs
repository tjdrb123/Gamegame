using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private string objectToSpawnTag;  // 오브젝트 풀에서 스폰하려는 오브젝트의 태그
    [SerializeField] private GameObject[] positionObjects;
    private List<GameObject> spawnObjects;


    private void Awake()
    {
        spawnObjects = new List<GameObject>(positionObjects);
    }

    private IEnumerator Start()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(5);  // 5초 간격으로 스폰
        }
    }

    private void SpawnObject()
    {
        // 랜덤한 위치에서 오브젝트 스폰
        if (spawnObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnObjects.Count);
            GameObject spawnLocation = spawnObjects[randomIndex];
            GameObject spawnedObject = ObjectPool.Instance.SpawnFromPool(objectToSpawnTag);

            if (spawnedObject != null)
            {
                spawnedObject.transform.position = spawnLocation.transform.position;
                spawnedObject.SetActive(true);
            }
        }
    }
}
