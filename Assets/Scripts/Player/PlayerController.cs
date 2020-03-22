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
    private float maxX = 5.2f;
    private float maxY = 8.7f;
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
            if ( point.x > x)
                x = Math.Min(Math.Min(x + real_speed, point.x), maxX);
            else if (point.x < x)
                x = Math.Max(Math.Max(x - real_speed, point.x), -maxX);

            if (point.y > y)
                y = Math.Min(Math.Min(y + real_speed, point.y), maxY);
            else if (point.y < y)
                y = Math.Max(Math.Max(y - real_speed, point.y), -maxY);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
