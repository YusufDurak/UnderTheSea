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

        bool spawnLeft = Random.Range(0, 2) == 0; // Randomly choose to spawn from left or right group
        Transform spawnPoint = spawnLeft
            ? leftSpawnPoints[Random.Range(0, leftSpawnPoints.Length)]
            : rightSpawnPoints[Random.Range(0, rightSpawnPoints.Length)];

        GameObject newMine = Instantiate(minePrefab, spawnPoint.position, Quaternion.identity);

        // Set the mine's movement direction based on its spawn position
        MineMovement mineMovement = newMine.GetComponent<MineMovement>();
        if (mineMovement != null)
        {
            mineMovement.SetDirection(spawnLeft ? Vector2.left : Vector2.right);
        }
    }
}
