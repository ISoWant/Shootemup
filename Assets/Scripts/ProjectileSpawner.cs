using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D projectileObject;

    [SerializeField]
    float speed;

    [SerializeField]
    float fireDelay = 0;

    float timeDelta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeDelta >= fireDelay) {
            Rigidbody2D projectileInstance = Instantiate(projectileObject, transform.position, Quaternion.identity);
            projectileInstance.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
            timeDelta = 0;
        }
    }

    private void Update()
    {
        timeDelta += Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //Destroy(projectileObject);
    }
}
