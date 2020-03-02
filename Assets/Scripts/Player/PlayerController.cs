using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Скорость движения самолёта.")]
    [SerializeField] private float speed = 1;
    [SerializeField] private GameObject plane;
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
        if (Input.GetMouseButton(0) && plane != null)
        {
            Vector3 point = new Vector3();
            Vector3 mousePos = Input.mousePosition;
            float x = transform.position.x;
            float y = transform.position.y;
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            float real_speed = speed * Time.deltaTime;
            if ( point.x > x + position_accuracy && x < max_x)
                x = Math.Max(x + real_speed, point.x);
            else if (point.x < x - position_accuracy && x > -max_x)
                x = Math.Min(x - real_speed, point.x);

            if (point.y > y + position_accuracy && y < max_y)
                y = Math.Max(y + real_speed, point.y);
            else if (point.y < y - position_accuracy && y > -max_y)
                y = Math.Min(y - real_speed, point.y);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
