using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class ParticleBehaviour : MonoBehaviour
    {
        public Particle _particle;

        // Use this for initialization
        void Start()
        {
            _particle.velocity = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = _particle.position;
            ApplyForce();
        }

        void ApplyForce()
        {
            _particle.acceleration = _particle.force;
            _particle.velocity += _particle.acceleration * Time.deltaTime;
            _particle.position += _particle.velocity * Time.deltaTime;
        }
    }
}