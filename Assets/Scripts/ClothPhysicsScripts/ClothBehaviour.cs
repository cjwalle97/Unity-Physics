﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class ClothBehaviour : MonoBehaviour
    {
        private List<GameObject> _objects;
        private List<Particle> _particles;
        private List<ParticleBehaviour> _particlebehaviours;
        private List<SpringDamperBehaviour> _springdamperbehaviours;
        private List<Triangles> _triangles;
        private Triangles test;

        public int _width;
        public int _height;

        // Use this for initialization
        void Start()
        {
            _width = 5;
            _height = 5;
            _objects = new List<GameObject>();
            _particles = new List<Particle>();
            _springdamperbehaviours = new List<SpringDamperBehaviour>();
            _particlebehaviours = new List<ParticleBehaviour>();
            _triangles = new List<Triangles>();
            CreateParticles();
            AlignParticles();
            LockParticles();
            for (int i = 0; i < _height; i++)
            {
                CreateRow(i);
            }
            for (int r = 0; r < _width; r++)
            {
                CreateColumn(r);
            }
            //test = new AerodynamicForce(_particles[0], _particles[1], _particles[5]);
            CreateTriangles();
            
        }

        // Update is called once per frame
        void Update()
        {
            ObjectPositioning();
            for (int i = 0; i < 32; i++)
            {
                _triangles[i].AeroDynamicForces();
            }
        }

        void CreateParticles()
        {
            for (int i = 0; i < (_width * _height); i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var par = new Particle();
                go.name = string.Format("{0} {1}", "Particle: ", i);
                var pbh = go.AddComponent<ParticleBehaviour>();
                pbh._particle = par;
                _particlebehaviours.Add(pbh);
                _objects.Add(go);
                _particles.Add(par);
            }
        }

        void CreateRow(int row)
        {
            for (int k = 0; k < _width - 1; k++)
            {
                var go1 = new GameObject();
                go1.name = "Spring Damper 1";
                var dmp1 = go1.AddComponent<SpringDamperBehaviour>();
                dmp1._particle1 = _particles[k + (5 * row)];
                dmp1._object1 = _objects[k + (5 * row)];
                dmp1._particle2 = _particles[k + 1 + (5 * row)];
                dmp1._object2 = _objects[k + 1 + (5 * row)];
            }
            for (int i = 0; i < _width - 2; i++)
            {
                var go2 = new GameObject();
                go2.name = "Spring Damper 2";
                var dmp2 = go2.AddComponent<SpringDamperBehaviour>();
                dmp2._particle1 = _particles[i + (5 * row)];
                dmp2._object1 = _objects[i + (5 * row)];
                dmp2._particle2 = _particles[i + 2 + (5 * row)];
                dmp2._object2 = _objects[i + 2 + (5 * row)];
            }
        }

        void CreateColumn(int column)
        {
            for (int i = 0; i < _height - 1; i++)
            {
                var go3 = new GameObject();
                go3.name = "Spring Damper 3";
                var dmp3 = go3.AddComponent<SpringDamperBehaviour>();
                dmp3._particle1 = _particles[column + (i * 5)];
                dmp3._object1 = _objects[column + i * 5];
                dmp3._particle2 = _particles[column + (i * 5) + 5];
                dmp3._object2 = _objects[column + (i * 5) + 5];
            }

            for (int k = 0; k < _height - 2; k++)
            {
                var go4 = new GameObject();
                go4.name = "Spring Damper 4";
                var dmp4 = go4.AddComponent<SpringDamperBehaviour>();
                dmp4._particle1 = _particles[column + k * 5];
                dmp4._object1 = _objects[column + k * 5];
                dmp4._particle2 = _particles[column + (k * 5) + 10];
                dmp4._object2 = _objects[column + (k * 5) + 10];
            }
        }

        void AlignParticles()
        {
            for (int k = 0; k < _height; k++)
            {
                for (int i = 0; i < _width; i++)
                {
                    Vector3 newposition = new Vector3(i * 10, k * 10, 0.0f);
                    _particles[i + (k * _width)].position = newposition;
                }
            }
        }

        void LockParticles()
        {
            _particles[0].locked = true;
            _particles[4].locked = true;
            _particles[5].locked = true;
            _particles[9].locked = true;
            _particles[10].locked = true;
            _particles[14].locked = true;
            _particles[15].locked = true;
            _particles[19].locked = true;
            _particles[20].locked = true;
            _particles[24].locked = true;
        }

        void ObjectPositioning()
        {
            for (int i = 0; i < _height * _width; i++)
            {
                _objects[i].transform.position = _particles[i].position;
            }
        }

        void CreateTriangles()
        {
            // 20 -21 -22 -23 -24
            //  | \ | \ | \ | \ |
            // 15 -16 -17 -18 -19
            //  | \ | \ | \ | \ |
            // 10 -11 -12 -13 -14
            //  | \ | \ | \ | \ |
            //  5 - 6 - 7 - 8 - 9
            //  | \ | \ | \ | \ |
            //  0 - 1 - 2 - 3 - 4
            var t1 = new Triangles(_particles[0], _particles[1], _particles[5]);
            var t2 = new Triangles(_particles[1], _particles[6], _particles[5]);
            var t3 = new Triangles(_particles[1], _particles[2], _particles[6]);
            var t4 = new Triangles(_particles[1], _particles[7], _particles[6]);
            var t5 = new Triangles(_particles[2], _particles[3], _particles[7]);
            var t6 = new Triangles(_particles[3], _particles[8], _particles[7]);
            var t7 = new Triangles(_particles[3], _particles[4], _particles[8]);
            var t8 = new Triangles(_particles[4], _particles[9], _particles[8]);
            var t9 = new Triangles(_particles[5], _particles[6], _particles[10]);
            var t10 = new Triangles(_particles[6], _particles[11], _particles[10]);
            var t11 = new Triangles(_particles[6], _particles[7], _particles[11]);
            var t12 = new Triangles(_particles[7], _particles[12], _particles[11]);
            var t13 = new Triangles(_particles[7], _particles[8], _particles[12]);
            var t14 = new Triangles(_particles[8], _particles[13], _particles[12]);
            var t15 = new Triangles(_particles[8], _particles[9], _particles[13]);
            var t16 = new Triangles(_particles[9], _particles[14], _particles[13]);
            var t17 = new Triangles(_particles[10], _particles[11], _particles[15]);
            var t18 = new Triangles(_particles[11], _particles[16], _particles[15]);
            var t19 = new Triangles(_particles[11], _particles[12], _particles[16]);
            var t20 = new Triangles(_particles[12], _particles[17], _particles[16]);
            var t21 = new Triangles(_particles[12], _particles[13], _particles[17]);
            var t22 = new Triangles(_particles[13], _particles[18], _particles[17]);
            var t23 = new Triangles(_particles[13], _particles[14], _particles[18]);
            var t24 = new Triangles(_particles[14], _particles[19], _particles[18]);
            var t25 = new Triangles(_particles[15], _particles[16], _particles[20]);
            var t26 = new Triangles(_particles[16], _particles[21], _particles[20]);
            var t27 = new Triangles(_particles[16], _particles[17], _particles[21]);
            var t28 = new Triangles(_particles[17], _particles[22], _particles[21]);
            var t29 = new Triangles(_particles[17], _particles[18], _particles[22]);
            var t30 = new Triangles(_particles[18], _particles[23], _particles[22]);
            var t31 = new Triangles(_particles[18], _particles[19], _particles[23]);
            var t32 = new Triangles(_particles[19], _particles[24], _particles[23]);

            _triangles.Add(t1);
            _triangles.Add(t2);
            _triangles.Add(t3);
            _triangles.Add(t4);
            _triangles.Add(t5);
            _triangles.Add(t6);
            _triangles.Add(t7);
            _triangles.Add(t8);
            _triangles.Add(t9);
            _triangles.Add(t10);
            _triangles.Add(t11);
            _triangles.Add(t12);
            _triangles.Add(t13);
            _triangles.Add(t14);
            _triangles.Add(t15);
            _triangles.Add(t16);
            _triangles.Add(t17);
            _triangles.Add(t18);
            _triangles.Add(t19);
            _triangles.Add(t20);
            _triangles.Add(t21);
            _triangles.Add(t22);
            _triangles.Add(t23);
            _triangles.Add(t24);
            _triangles.Add(t25);
            _triangles.Add(t26);
            _triangles.Add(t27);
            _triangles.Add(t28);
            _triangles.Add(t29);
            _triangles.Add(t30);
            _triangles.Add(t31);
            _triangles.Add(t32);
        }

    }

    public class Triangles
    {
        private float _Cd; //drag for the object
        private float _a; //cross sectional area
        private Vector3 _n; // normal of the triangle
        private Vector3 _e; //vector in the opposite direction of the velocity
        private Particle _r1; //Particle 1
        private Particle _r2; //Particle 2
        private Particle _r3; //Particle 3
        private Vector3 _v1; //Velocity of Particle 1
        private Vector3 _v2; //Velocity of Particle 2
        private Vector3 _v3; //Velocity of Particle 3
        private Vector3 _Vsurface; // = (v1 + v2 + v3) / 3
        private Vector3 _Vair; // = -density
        private Vector3 _v;

        public Vector3 Force;

        public Triangles(Particle p1, Particle p2, Particle p3)
        {
            _r1 = p1;
            _v1 = _r1.velocity;
            _r2 = p2;
            _v2 = _r2.velocity;
            _r3 = p3;
            _v3 = _r3.velocity;
            _Vsurface = (_v1 + _v2 + _v3) / 3;
            _Vair = new Vector3(1.0f, 0, 1.0f);
            _v = _Vsurface - _Vair;
        }

        public void AeroDynamicForces()
        {
            //n= ((r2 - r1) x (r3 - r1))/|(r2 - r1) x (r3 -r1))|
            _n = (Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position))) / (Vector3.Magnitude(Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position))));
            //ao = 1/2 |(r2 - r1) x (r3 -r1)|
            var ao = (1 / 2) * Vector3.Magnitude(Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position)));
            _a = (Vector3.Dot(_v, _n) / Vector3.Magnitude(_v));
            var n = Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position));
            var force = (Vector3.Magnitude(_v) * Vector3.Dot(_v, n) / (2 * Vector3.Magnitude(n))) * n;
            Force = force / 3;

            _r1.wind = Force;
            _r2.wind = Force;
            _r3.wind = Force;
        }
    }
}