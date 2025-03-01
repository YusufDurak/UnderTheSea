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
    private float lastspawnChangeTime = 1f;
    public float spawnChangeCooldown = 0.5f; // Cooldown time in seconds
    int randomNumber= Random.Range(1, 7);
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
        randomNumber = Random.Range(1, 7);
        if (randomNumber%2==0)
        {
            Debug.Log("tr");
            if (objectPrefab != null)
            {
                Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
                purna = false;
            }
        }
        if (randomNumber % 2 != 0)
        {
            Debug.Log("fl");          

            if (objectPrefab != null )
            {
                
                Instantiate(Prefab, Point.position, Quaternion.identity);
                purna = true;
                lastspawnChangeTime = Time.time+3f;
            }
        }
        randomNumber = 0;
    }
}
