using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, iShip
{
    [SerializeField]
    private ShipState state;

    public void TakeDamage( int damage )
    {
        state.currentHP -= damage;
    }
}
