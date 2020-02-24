using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objScroll : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }
}
