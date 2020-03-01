using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialProjectiles : MonoBehaviour
{
    float timeDelta = 0f;

    [SerializeField] GameObject missilePrefab;
    
    [SerializeField] private float release;

    private bool ableFire = true;

    private void Update()
    {
        if (ableFire == true)
        {
            fire();
        }
        timeDelta += Time.deltaTime;
        if (timeDelta >= release)
        {
            ableFire = true;
            timeDelta = 0;
        }
        Debug.Log(ableFire);
    }

    public void fire()
    {
        if (Input.GetButtonDown("Jump"))
        {
                Vector2 missileSpawnPoint = new Vector2(transform.position.x, transform.position.y);
                GameObject _missile = Instantiate(missilePrefab, missileSpawnPoint, Quaternion.identity);
            ableFire = false;   
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(missilePrefab);
    }
}
