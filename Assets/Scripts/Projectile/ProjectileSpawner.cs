using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;


    [SerializeField]
    float fireDelay = 0;

    float timeDelta = 0;

    bool isFiringBullet = true;

    private void Update()
    {
            bullet();
    }

    public void bullet()
    {
        timeDelta += Time.deltaTime;
        if (timeDelta >= fireDelay)
        {
            Vector2 bulletSpawnPoint = new Vector2(transform.position.x, transform.position.y);
            GameObject _bullet = Instantiate(bulletPrefab, bulletSpawnPoint, Quaternion.identity);
            timeDelta = 0;
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(bulletPrefab);
    }
}
