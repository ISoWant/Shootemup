using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] levels;

    
    void Update()
    {
        foreach (GameObject obj in levels)
        {
            float y = obj.transform.position.y;
            if (y < -10 )
                obj.transform.position = new Vector3(obj.transform.position.x, 15f, obj.transform.position.z);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - speed, obj.transform.position.z);
        }
    }
}
