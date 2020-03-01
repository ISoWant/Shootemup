using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private PlaneBehavior plane;

    private void Start()
    {
        Debug.Assert(plane != null, "Не задан объект 'plane' (для определения полосы HP).");
    }

    void Update()
    {
        float HP = plane.GetRelativeHP();
        if (HP <= 0)
            Destroy(gameObject);
        else
            transform.localScale = new Vector3(HP, 1, 1);
    }
}
