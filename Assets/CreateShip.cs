using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab; // Prefab to spawn
    [SerializeField] private Transform spawnPoint; // Spawn position
    [SerializeField] private float spawnInterval = 5f; // Time interval

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObject()
    {
        if (objectPrefab != null)
        {
            Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
