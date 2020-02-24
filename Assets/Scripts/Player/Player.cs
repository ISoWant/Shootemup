using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, iShip
{
    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private int Power;
    [SerializeField]
    private Transform[] firePoints;

    public void TakeDamage( int damage )
    {
        currentHP -= damage;
    }

    public bool IsAlive()
    {
        return currentHP > 0;
    }
}
