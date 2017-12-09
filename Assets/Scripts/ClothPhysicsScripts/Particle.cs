using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class Particle
    {
        public Vector3 position;
        public Vector3 velocity;
        [SerializeField]
        Vector3 acceleration;
        [SerializeField]
        float mass;
        public Vector3 force;

        public void ApplyForce()
        {
            acceleration = force;
            velocity += acceleration * Time.deltaTime;
            position += velocity * Time.deltaTime;
        }
    }
}