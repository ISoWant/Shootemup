using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int HP = 20;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        if (projectile != null)
            HP -= projectile.getDamage();
        else
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
                HP = 0;
        }
    }

    public int GetHP()
    {
        return HP;
    }
}
