using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class Particle
    {
        [SerializeField]
        public Vector3 position;
        [SerializeField]
        public Vector3 velocity;
        [SerializeField]
        public Vector3 acceleration;
        [SerializeField]
        public float mass;
        [SerializeField]
        public Vector3 force;

        public void Update()
        {
            
        }
    }
}