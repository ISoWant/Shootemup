using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject boss;
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private float bossSpawnTime;
    float randX;
    Vector2 spawnPoint;
    float nextSpawn = 0.0f;
    private bool hasBoss = false;
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= bossSpawnTime)
        {
            if (!hasBoss)
            {
                Instantiate(boss, new Vector2(0, transform.position.y), Quaternion.identity);
                hasBoss = true;
            }
        }
        else if (Time.time >= nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.3f, 2.3f);
            spawnPoint = new Vector2(randX, transform.position.y);
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
}
