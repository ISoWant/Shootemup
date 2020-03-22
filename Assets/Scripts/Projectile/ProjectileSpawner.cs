using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireDelay = 0;
    [Tooltip("Пуля летит вверх?")]
    [SerializeField] private bool direction = true;
    private float timeDelta = 0;
    private bool isFiringBullet = true;

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
            _bullet.GetComponent<Projectile>().SetDirection(direction);
            timeDelta = 0;
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(bulletPrefab);
    }
}
