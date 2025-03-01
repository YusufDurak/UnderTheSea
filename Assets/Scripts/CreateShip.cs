using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab; // Prefab to spawn
    [SerializeField] private GameObject Prefab; // Prefab to spawn
    [SerializeField] private Transform spawnPoint; // Spawn position
    [SerializeField] private Transform Point; // Spawn position
    [SerializeField] private float spawnInterval = 3f; // Time interval
    public bool purna = true;

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
        if (purna)
        {
            Debug.Log("tr");
            if (objectPrefab != null)
            {
                Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
                purna = false;
            }
        }
        if (purna==false)
        {
            Debug.Log("fl");

            if (objectPrefab != null)
            {
                Instantiate(Prefab, Point.position, Quaternion.identity);
                purna = true;
            }
        }

    }
}
