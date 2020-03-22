﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossBehavior : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private float maxHP = 20f;
    [SerializeField] private float maxX = 4.4f;
    [SerializeField] private float minY = 8.75f;
    private float HP;
    bool direction = true;

    private void Start()
    {
        HP = maxHP;
    }

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float speed_ = speed * Time.deltaTime;
        if (y > minY)
            y -= speed_;
        else if (direction)
        {
            x -= speed_;
            direction = x > -maxX;
        }
        else
        {
            x += speed_;
            direction = x >= maxX;
        }

        transform.position = new Vector3(x, y, transform.position.z);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
