using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeBetweenSpawns;
    float nextSpawnTime;

    public GameObject enemy;

    public Transform[] spawnPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
            Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);
        }
    }
}
