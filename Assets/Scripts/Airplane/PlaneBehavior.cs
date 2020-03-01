using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class PlaneBehavior : MonoBehaviour
{
    [SerializeField] private int maxHP = 20;
    [SerializeField] private Slider HPBar;

    private void Start()
    {
        HPBar.maxValue = maxHP;
        HPBar.value = maxHP;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        if (projectile != null)
            HPBar.value -= projectile.getDamage();
        else
        {
            PlaneBehavior planeBehavior = collision.GetComponent<PlaneBehavior>();
            if (planeBehavior != null)
                HPBar.value = 0;
        }
    }

    public float GetHP()
    {
        return HPBar.value;
    }
}
