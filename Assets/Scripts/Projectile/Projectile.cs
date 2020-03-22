using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int speed;
    [Tooltip("Пуля летит вверх?")]
    [SerializeField] private bool direction = true;

    public int getDamage()
    {
        return damage;
    }
    
    void Update()
    {
        float y = direction ? transform.position.y + speed * Time.deltaTime : transform.position.y - speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obstacle = collision.gameObject;
        if (obstacle != null && gameObject.tag != obstacle.tag)
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    internal void SetDirection(bool direct)
    {
        direction = direct;
    }
}
