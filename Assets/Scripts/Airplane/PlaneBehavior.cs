using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class PlaneBehavior : MonoBehaviour
{
    [SerializeField] private int maxHP = 20;
    [SerializeField] private int HP = 20;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        if (projectile != null)
            HP -= projectile.getDamage();
        else
        {
            PlaneBehavior planeBehavior = collision.GetComponent<PlaneBehavior>();
            if (planeBehavior != null)
                HP = 0;
        }
    }

    public int GetHP()
    {
        return HP;
    }
}
