using UnityEngine;
using System.Collections;

public class MineSpawner : MonoBehaviour
{
    [SerializeField] private GameObject minePrefab; // Mine prefab
    [SerializeField] private Transform[] leftSpawnPoints;  // Locations where mines move left
    [SerializeField] private Transform[] rightSpawnPoints; // Locations where mines move right
    [SerializeField] private float spawnInterval = 8f; // Time between spawns

    private void Start()
    {
        StartCoroutine(SpawnMines());
    }

    private IEnumerator SpawnMines()
    {
        while (true)
        {
            SpawnMine();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnMine()
    {
        if (minePrefab == null || leftSpawnPoints.Length == 0 || rightSpawnPoints.Length == 0) return;

        bool spawnLeft = Random.Range(0, 2) == 0; // Randomly choose left or right spawn
        Transform spawnPoint = spawnLeft
            ? leftSpawnPoints[Random.Range(0, leftSpawnPoints.Length)]
            : rightSpawnPoints[Random.Range(0, rightSpawnPoints.Length)];

        // Set rotation based on spawn side
        Quaternion mineRotation = Quaternion.Euler(0, 0, spawnLeft ? 90f : -90f);

        GameObject newMine = Instantiate(minePrefab, spawnPoint.position, mineRotation);

        // Set movement direction based on spawn side
        MineMovement mineMovement = newMine.GetComponent<MineMovement>();
        if (mineMovement != null)
        {
            mineMovement.SetDirection(spawnLeft ? Vector2.left : Vector2.right);
        }
    }

}
