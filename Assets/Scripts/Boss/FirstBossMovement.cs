using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossMovement : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private float maxX = 4.4f;
    [SerializeField] private float minY = 8.75f;
    bool direction = true;
    private float next_pattern_time = 0;
    private int pattern = 0;

    void Update()
    {
        if (next_pattern_time <= Time.time && pattern != 0)
            pattern = 1;

        switch (pattern)
        {
            case 0: Appearance();              break;
            case 1: MovementInUpperCorners();  break;
            default: break;
        }
    }

    private void Appearance()
    {
        if (transform.position.y > minY)
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        else
        {
            pattern = 1;
            gameObject.GetComponentInChildren<Collider2D>().enabled = true;

            foreach (ProjectileSpawner firePoint in gameObject.GetComponentsInChildren<ProjectileSpawner>())
                firePoint.enabled = true;
        }
    }

    private void MovementInUpperCorners()
    {
        float x = transform.position.x;
        float speed_ = speed * Time.deltaTime;

        if (direction)
        {
            x -= speed_;
            direction = x > -maxX;
            if (x <= 0 && x > -speed_)
                x = 0;
        }
        else
        {
            x += speed_;
            direction = x >= maxX;
        }

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        if (x.Equals(0))
            PatternComplition();
    }
    
    private void PatternComplition()
    {
        next_pattern_time = Time.time + 5f;
        pattern = 2;
    }
}
