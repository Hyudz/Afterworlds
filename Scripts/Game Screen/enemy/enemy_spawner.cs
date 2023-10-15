using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    [Header("Targetable Enemies")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Properties")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public float spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy(spawnInterval));
        spawnPoint = GetComponent<Transform>();
    }

    private IEnumerator SpawnRandomEnemy(float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            // Choose a random enemy prefab from the array
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];

            // Spawn the selected enemy prefab
            GameObject newEnemy = Instantiate(randomEnemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
