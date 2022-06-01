using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


namespace Maze
{
    
public class BadBonus : Bonus, IRotation, IFly
{
    private float _heightFly;
    private float _speedRotation;

    public event Action <string, Color> OnCaughtPlayer = delegate(string str, Color color) {  };
    


    public void Awake()
    {
        base.Awake();
        _heightFly = Random.Range(1f, 5f);
        _speedRotation = Random.Range(15f, 80f);
    }
    
    public override void Update()
    {
        Rotate();
        Fly();
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);

    }
    public void Fly()
    {
        transform.position =
            new Vector3(transform.position.x, Mathf.PingPong(Time.time, _heightFly), transform.position.z);

    }
    protected override void Interaction()
    {
        OnCaughtPlayer.Invoke(gameObject.name, _color);   
    }
}
}
