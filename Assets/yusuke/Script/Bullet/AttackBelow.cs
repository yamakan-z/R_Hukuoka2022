using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttackBelow : MonoBehaviour
{
    private float Speed; //‘¬“x

    public Rigidbody2D rb;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector2 force = new Vector2(0.0f, 8.5f);
        rb.AddForce(force, ForceMode2D.Force);
    }
}
