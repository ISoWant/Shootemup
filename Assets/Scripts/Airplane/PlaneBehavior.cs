using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class PlaneBehavior : MonoBehaviour
{
    [SerializeField] private float maxHP = 20f;
    private float HP;

    private void Start()
    {
        HP = maxHP;
    }
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

    public float GetHP()
    {
        return HP;
    }

    public float GetRelativeHP()
    {
        return HP / maxHP;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
