using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    
public sealed class PlayerMovement : Unit
{
    private void Awake()
    {
        _transform = transform;
        if (GetComponent<Rigidbody>())
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        isDead = false;
        health = 100;

    }

    public override void Move(float x, float y, float z)
    {
        if (!rigidbody)
        {
            Debug.Log("No Rigidbody");
            return;
        }
        rigidbody.AddForce(new Vector3(x, y, z) * speed);
    }
    
    
}
}
