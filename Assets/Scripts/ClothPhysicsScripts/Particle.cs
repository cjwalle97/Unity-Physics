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
        public Vector3 force = Vector3.zero;
        public bool locked;

        public void ApplyForce()
        {
            acceleration = force;
            velocity += acceleration * Time.deltaTime;
            position += velocity * Time.deltaTime;
        }
    }
}