using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, iShip
{
    [SerializeField] private int maxHP = 10;
    [SerializeField] private int currentHP = 10;

    public void TakeDamage( int damage )
    {
        currentHP -= damage;
    }

    public bool IsAlive()
    {
        return currentHP > 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
