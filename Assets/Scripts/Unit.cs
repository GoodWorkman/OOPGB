using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    
    public abstract class Unit : MonoBehaviour
    {
        public Rigidbody rigidbody;
        public Transform _transform;
        
        public static float speed = 5f;
        public static int health = 100;
        public static bool isDead;

        public abstract void Move(float x, float y, float z);

    }

}
