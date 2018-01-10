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
        public Vector3 wind = Vector3.zero;
        public bool locked;

        private Vector3 _gravity;

        public void ApplyForce()
        {
            if(!locked)
            {
                mass = 1;
                _gravity = mass * new Vector3(0, -9.81f, 0);
                acceleration = force + wind + _gravity;
                velocity += acceleration * Time.deltaTime;
                position += velocity * Time.deltaTime;
            }
        }
    }
}