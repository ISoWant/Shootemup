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
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            float real_speed = speed * Time.deltaTime;
            if ( point.x > transform.position.x + position_accuracy && transform.position.x < max_x)
                transform.position = new Vector3(Math.Max(transform.position.x + real_speed, point.x), transform.position.y, transform.position.z);
            else if (point.x < transform.position.x - position_accuracy && transform.position.x > -max_x)
                transform.position = new Vector3(Math.Min(transform.position.x - real_speed, point.x), transform.position.y, transform.position.z);

            if (point.y > transform.position.y + position_accuracy && transform.position.y < max_y)
                transform.position = new Vector3(transform.position.x, Math.Max(transform.position.y + real_speed, point.y), transform.position.z);
            else if (point.y < transform.position.y - position_accuracy && transform.position.y > -max_y)
                transform.position = new Vector3(transform.position.x, Math.Min(transform.position.y - real_speed, point.y), transform.position.z);
        }
    }
}
