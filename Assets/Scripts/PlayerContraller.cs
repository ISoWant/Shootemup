using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]

public class PlayerContraller : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Скорость движения самолёта.")]
    [SerializeField] private float speed;
    [Header("Fire")]
    [Tooltip("Скорость с которой выпускаются пули.")]
    [SerializeField] private int fireSpeed;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 point = new Vector3();
            Vector3 mousePos = Input.mousePosition;
            point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            Debug.Log("mousePos.x = " +  mousePos.x + ", my = " + transform.position.x + ", point.x = " + point.x);
            if ( point.x > transform.position.x + 0.1f && transform.position.x < 2.5f)
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            else if (point.x < transform.position.x - 0.1f && transform.position.x > -2.5f)
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            if (point.y > transform.position.y + 0.1f && transform.position.y < 4.3f)
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            else if (point.y < transform.position.y - 0.1f && transform.position.y > -4.3f)
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
    }

    private void LaunchBulet()
    {
    }

    private IEnumerator Fire()
    {
        while (GetComponent<Player>().IsAlive())
        {
            LaunchBulet();
            yield return new WaitForSeconds(fireSpeed);
        }
    }


}
