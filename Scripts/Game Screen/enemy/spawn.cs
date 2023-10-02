using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    [SerializeField] private GameObject enemy1;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy1(spawnInterval, enemy1));
        spawnPoint = GetComponent<Transform>();
        
    }

    private IEnumerator spawnEnemy1(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnInterval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(spawnPoint.position.x,spawnPoint.position.y,0), Quaternion.identity);
        //GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f),0), Quaternion.identity);

        StartCoroutine(spawnEnemy1(interval, enemy));
    }
}
