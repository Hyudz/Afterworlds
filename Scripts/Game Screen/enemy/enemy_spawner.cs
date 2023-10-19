using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    [Header("Targetable Enemies")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Properties")]
    [SerializeField] public float spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemy(spawnInterval));
    }

    private IEnumerator SpawnRandomEnemy(float interval)
    {
        while (true)
        {

            float randomX = Random.Range(-3600, -340);
            float randomY = Random.Range(2180, 727);
            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

            yield return new WaitForSeconds(interval);

            // Choose a random enemy prefab from the array
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];

            // Spawn the selected enemy prefab
            GameObject newEnemy = Instantiate(randomEnemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}
