using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField]
    int damage;

    public int getDamage()
    {
        return damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
