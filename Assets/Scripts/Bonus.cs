using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    
public abstract class Bonus : MonoBehaviour,IExecute
{
    private bool _isIntecactable;
    public Transform transform;

    public bool isIntecactable
    {
        get { return _isIntecactable; }
        private set
        {
            _isIntecactable = value;
            GetComponent<Renderer>().enabled = value;
            GetComponent<Collider>().enabled = value;
        }
    }

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void Start()
    {
        isIntecactable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerMovement playerMovement = other.attachedRigidbody.GetComponent<PlayerMovement>();
            if (playerMovement)
            {
                Interaction();
                isIntecactable = false;
            }
        }
    }
    protected abstract void Interaction();
    public abstract void Update();
    
}

}
