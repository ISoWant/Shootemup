using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Animator explosion;

    private void Start()
    {
        explosion = GetComponent<Animator>();
    }

    public void DestroyPlane()
    {
        explosion.SetBool("isDestroyed", true);
    }
    public void ClearSmoke()
    {
        explosion.SetBool("isCleared", true);
    }
}
