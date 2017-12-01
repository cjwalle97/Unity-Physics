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

        public SpringDamper() { }

        public SpringDamper(Particle p1, Particle p2, float ks, float kd, float lo)
        {
            _p1 = p1;
            _p2 = p2;
            _ks = ks;
            _kd = kd;
            _lo = lo;
        }

        public void CalculateForce()
        {
            //Computes the spring force by using the position variables of both _p1 and _p2 
            var e = _p2.position - _p1.position;
            var l = Vector3.Magnitude(e);
            var newe = e / l;

            //computes the spring force as 1D float variable.
            var V1 = _p1.velocity;
            var V2 = _p2.velocity;
            var newV1 = Vector3.Dot(newe, V1);
            var newV2 = Vector3.Dot(newe, V2);

            //Changes the 1D float variable into a 3D Vector
            var Fs = -_ks * (_lo - l);
            var Fd = _kd * (newV1 - newV2);
            var F = Fs - Fd;
            var f1 = F * newe;
            var f2 = -f1;

            _p1.force = f1;
            _p2.force = f2;
        }
    }
}