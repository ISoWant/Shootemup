using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int speed = 1;
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject explosion;
    private EnemyBehavior planeBehavior;
    private Animator explosionAnimator;

    private void Start()
    {
        planeBehavior = plane.GetComponent<EnemyBehavior>();
        explosionAnimator = explosion.GetComponent<Animator>();
        Debug.Assert(planeBehavior != null, "У объеката 'plane' не задан скрипт поведения (для определения HP).");
        Debug.Assert(explosionAnimator != null, "У объеката 'explosion' не задан аниматор.");
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        
        if (planeBehavior.GetHP() <= 0)
        {
            if(!explosion.activeSelf)
                explosion.SetActive(true);
            if (explosionAnimator.GetBool("isDestroyed"))
                Destroy(plane);
            if (explosionAnimator.GetBool("isCleared"))
                Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void DestroyPlane()
    {
        explosionAnimator.SetBool("isDestroyed", true);
    }
    public void ClearSmoke()
    {
        explosionAnimator.SetBool("isCleared", true);
    }
}
