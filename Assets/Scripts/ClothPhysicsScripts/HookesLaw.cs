using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookesLaw : MonoBehaviour
{
    [System.Serializable]
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

        public Particle()
        {
            position = Vector3.zero;
            velocity = Vector3.zero;
            acceleration = Vector3.zero;
            mass = 1;
        }

        public Particle(Vector3 p, Vector3 v, float m)
        {
            position = p;
            velocity = v;
            acceleration = Vector3.zero;
            mass = m;
        }

        public void Update()
        {
            acceleration = force / mass;
            velocity += acceleration * Time.deltaTime;
            position += velocity * Time.deltaTime;
        }
    }

    public class SpringDamper
    {
        Particle _p1, _p2;
        float _ks; //Springiness
        float _lo; //Rest Length

        public SpringDamper() { }

        public SpringDamper(Particle p1, Particle p2, float springConstant, float restLength)
        {
            _p1 = p1;
            _p2 = p2;
            _ks = springConstant;
            _lo = restLength;
        }
        public Vector3 FindDistance()
        {
            Vector3 Distance = _p1.position - _p2.position;
            return Distance;
        }
        public void GetForce(Particle p1, Particle p2, Vector3 Distance)
        {
            
        }
    }
}
//Find the unit distance from the 2 particles
//
//Convert from 1D to 3D
//Apply Force