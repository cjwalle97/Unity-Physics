using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class Particle
    {
        public Vector3 position;
        public Vector3 velocity;
        public Vector3 acceleration;
        public float mass;
        public Vector3 _gravity;
        public Vector3 force;
        public Vector3 wind;
        public bool locked;
        
        public void ApplyForce()
        {
            if(!locked)
            {
                acceleration = (force + wind + _gravity);
                velocity += acceleration * Time.deltaTime;
                position += velocity * Time.deltaTime;
            }
        }
    }
}