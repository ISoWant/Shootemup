using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour {

    public GameObject enemy;
    float randX;
    Vector2 spawnPoint;
    public float spawnRate = 5f;
    float nextSpawn = 0.0f;
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.3f, 2.3f);
            spawnPoint = new Vector2(randX, transform.position.y);
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
	}
}
