﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]

public class PlayerContraller : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Скорость движения самолёта.")]
    [SerializeField] private float speed = 1;
    private float max_x = 5.2f;
    private float max_y = 8.7f;
    private float position_accuracy = 0.1f;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 point = new Vector3();
            Vector3 mousePos = Input.mousePosition;
            float real_speed = speed * Time.deltaTime;
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            if ( point.x > transform.position.x + position_accuracy && transform.position.x < max_x)
                transform.position = new Vector3(transform.position.x + real_speed, transform.position.y, transform.position.z);
            else if (point.x < transform.position.x - position_accuracy && transform.position.x > -max_x)
                transform.position = new Vector3(transform.position.x - real_speed, transform.position.y, transform.position.z);

            if (point.y > transform.position.y + position_accuracy && transform.position.y < max_y)
                transform.position = new Vector3(transform.position.x, transform.position.y + real_speed, transform.position.z);
            else if (point.y < transform.position.y - position_accuracy && transform.position.y > -max_y)
                transform.position = new Vector3(transform.position.x, transform.position.y - real_speed, transform.position.z);
        }
    }
}
