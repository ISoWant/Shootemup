using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshTexture : MonoBehaviour
{
    [SerializeField] private float maxX;
    [SerializeField] private float speed = 0.01f;
    private const float real_size = 1f, half_size = 0.5f;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }
    public void OnBecameInvisible()
    {
        transform.position = new Vector3(Random.Range(-maxX, maxX), Random.Range(12.0f, 50.0f), transform.position.z);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f));
        transform.localScale = new Vector3(Random.Range(half_size, real_size), Random.Range(half_size, real_size), 0);
    }
}
