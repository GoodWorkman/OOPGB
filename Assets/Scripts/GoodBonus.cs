using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Maze
{
    
public class GoodBonus : Bonus, IFly, IFlicker
{
    private float _heightFly = 3f;
    [SerializeField] private Material material;
    public int score = 1;
    
    public event Action <int> AddScore = delegate (int i) {};  

    public void Awake()
    {
        base.Awake();
        material = GetComponent<Renderer>().material;
    }

    public override void Update()
    {
        Fly();
        Flick();
    }

    public void Fly()
    {
        transform.position =
            new Vector3(transform.position.x, Mathf.PingPong(Time.time, _heightFly), transform.position.z);
    }

    public void Flick()
    {
        material.color = 
            new Color(material.color.r, material.color.g, material.color.b, Mathf.PingPong(Time.time, 1f));
    }
    
    protected override void Interaction()
    {
        AddScore.Invoke(score);
    }
}
}
