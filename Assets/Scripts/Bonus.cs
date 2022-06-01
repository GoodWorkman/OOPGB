using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{
    
public abstract class Bonus : MonoBehaviour,IExecute
{
    private bool _isIntecactable;
    public Transform transform;
    protected Color _color;

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

    protected void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void Start()
    {
        isIntecactable = true;
        _color = Random.ColorHSV();

        if (TryGetComponent(out Renderer renderer))
        {
            renderer.sharedMaterial.color = _color;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isIntecactable||other.attachedRigidbody)
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
