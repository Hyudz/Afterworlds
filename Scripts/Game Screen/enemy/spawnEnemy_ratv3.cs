using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy_ratv3 : MonoBehaviour
{
    [Header("Targetable Enemy")]
    [SerializeField] private GameObject ratv3Prefab;

    [Header("Properties")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(spawnInterval, ratv3Prefab));
        spawnPoint = GetComponent<Transform>();
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemyPrefab)
    {
        new WaitForSeconds(3);
        while (true)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

}