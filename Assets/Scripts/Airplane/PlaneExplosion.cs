using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneExplosion : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject explosion;
    private PlaneBehavior planeBehavior;
    private Animator explosionAnimator;

    private void Start()
    {
        planeBehavior = plane.GetComponent<PlaneBehavior>();
        explosionAnimator = explosion.GetComponent<Animator>();
        Debug.Assert(planeBehavior != null, "У объеката 'plane' не задан скрипт поведения (для определения HP).");
        Debug.Assert(explosionAnimator != null, "У объеката 'explosion' не задан аниматор.");
    }

    void Update()
    {
        if (planeBehavior.GetHP() <= 0)
        {
            if (!explosion.activeSelf)
                explosion.SetActive(true);
            if (explosionAnimator.GetBool("isDestroyed"))
                Destroy(plane);
            if (explosionAnimator.GetBool("isCleared"))
                Destroy(gameObject);
        }
    }
}
