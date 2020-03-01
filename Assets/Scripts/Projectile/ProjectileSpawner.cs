﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireDelay = 0;
    private float timeDelta = 0;

    private void Update()
    {
        timeDelta += Time.deltaTime;
        if (timeDelta >= fireDelay)
        {
            Vector2 spawnPoint = new Vector2(transform.position.x, transform.position.y);
            GameObject _bullet = Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
            timeDelta = 0;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(bulletPrefab);
    }
}
