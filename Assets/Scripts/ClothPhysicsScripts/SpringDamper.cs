using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class SpringDamper
    {
        public Particle _p1;
        public Particle _p2;
        public float _ks;
        public float _kd;
        public float _lo;

        public SpringDamper()
        {
            _ks = 5.0f;
            _kd = 1.0f;
            _lo = 5.0f;
        }

        public SpringDamper(Particle p1, Particle p2, float ks, float kd, float lo)
        {
            _p1 = p1;
            _p2 = p2;
            _ks = ks;
            _kd = kd;
            _lo = lo;
        }

        public void ApplyGravity(float m)
        {
            _p1.mass = m;
            _p2.mass = m;
            _p1._gravity = m * new Vector3(0, -9.81f, 0);
            _p2._gravity = m * new Vector3(0, -9.81f, 0);
        }

        public void ApplyWind(Vector3 w)
        {
            _p1.wind = w;
        }

        public void CalculateForce()
        {
            //Computes the spring force by using the position variables of both _p1 and _p2
            var e = _p2.position - _p1.position;
            var l = Vector3.Magnitude(e);
            var newe = Vector3.Normalize(e) / l;

            //computes the spring force as 1D float variable.
            var V1 = _p1.velocity;
            var V2 = _p2.velocity;
            var v1 = Vector3.Dot(newe, V1);
            var v2 = Vector3.Dot(newe, V2);

            //Changes the 1D float variable into a 3D Vector
            var f = (-_ks * (_lo - l)) - (_kd * (v1 - v2));
            var f1 = f * newe;
            var f2 = -f1;

            _p1.force += f1;
            _p2.force += f2;

        }
    }
}