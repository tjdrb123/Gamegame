using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private string objectToSpawnTag;  // ������Ʈ Ǯ���� �����Ϸ��� ������Ʈ�� �±�
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
            yield return new WaitForSeconds(5);  // 5�� �������� ����
        }
    }

    private void SpawnObject()
    {
        // ������ ��ġ���� ������Ʈ ����
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
