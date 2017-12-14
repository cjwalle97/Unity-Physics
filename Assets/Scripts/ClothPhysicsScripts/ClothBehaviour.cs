using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class ClothBehaviour : MonoBehaviour
    {
        private List<GameObject> _objects;
        private List<Particle> _particles;
        private List<SpringDamperBehaviour> _springdamperbehaviours;
        private List<AerodynamicForce> _triangles;
        private AerodynamicForce test;

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
            CreateParticles();
            for (int i = 0; i < _height; i++)
            {
                CreateRow(i);
            }
            for (int r = 0; r < _width; r++)
            {
                CreateColumn(r);
            }
            AlignParticles();
            test = new AerodynamicForce(_particles[0], _particles[1], _particles[5]);
        }

        // Update is called once per frame
        void Update()
        {
            ObjectPositioning();
            test.CalculateForce();
        }

        void CreateParticles()
        {
            for (int i = 0; i < (_width * _height); i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var par = new Particle();
                go.name = string.Format("{0} {1}", "Particle: ", i);
                _objects.Add(go);
                _particles.Add(par);
            }
        }

        void CreateRow(int row)
        {
            for(int k = 0; k < _width - 1; k++)
            {
                var go1 = new GameObject();
                var dmp1 = go1.AddComponent<SpringDamperBehaviour>();
                dmp1._particle1 = _particles[k + (5 * row)];
                dmp1._object1 = _objects[k + (5 * row)];
                dmp1._particle2 = _particles[k + 1 + (5 * row)];
                dmp1._object2 = _objects[k + 1 + (5 * row)];
            }
            for (int i = 0; i < _width - 2; i++)
            {
                var go2 = new GameObject();
                var dmp2 = go2.AddComponent<SpringDamperBehaviour>();
                dmp2._particle1 = _particles[i + (5 * row)];
                dmp2._object1 = _objects[i + (5 * row)];
                dmp2._particle2 = _particles[i + 2 + (5 * row)];
                dmp2._object2 = _objects[i + 2 + (5 * row)];
            }
        }

        void CreateColumn(int column)
        {

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
        void ObjectPositioning()
        {
            for (int i = 0; i < _height * _width; i++)
            {
                _objects[i].transform.position = _particles[i].position;
            }
        }
        void CreateTriangles()
        {
            
        }
        // 20 -21 -22 -23 -24
        //  | \ | \ | \ | \ |
        // 15 -16 -17 -18 -19
        //  | \ | \ | \ | \ |
        // 10 -11 -12 -13 -14
        //  | \ | \ | \ | \ |
        //  5 - 6 - 7 - 8 - 9
        //  | \ | \ | \ |  \ |
        //  0 - 1 - 2 - 3 - 4
    }

    public class AerodynamicForce
    {
        private Vector3 _p = Vector3.one; //density of air

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

        public AerodynamicForce(Particle p1, Particle p2, Particle p3)
        {
            _r1 = p1;
            _v1 = _r1.velocity;
            _r2 = p2;
            _v2 = _r2.velocity;
            _r3 = p3;
            _v3 = _r3.velocity;
            _Vsurface = (_v1 + _v2 + _v3) / 3;
            _Vair = _p;
            _v = _Vsurface - _Vair;
        }

        public void CalculateForce()
        {
            //n= ((r2 - r1) x (r3 - r1))/|(r2 - r1) x (r3 -r1))|
            _n = Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position)) / Vector3.Magnitude(Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position)));
            //ao = 1/2 |(r2 - r1) x (r3 -r1)|
            var ao = 1 / 2 * Vector3.Magnitude(Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position)));
            _a = ao * (Vector3.Dot(_v, _n) / Vector3.Magnitude(_v));
            var n = Vector3.Cross((_r2.position - _r1.position), (_r3.position - _r1.position));
            var force = (Vector3.Magnitude(_v) * Vector3.Dot(_v, n) / (2 * Vector3.Magnitude(n))) * n;
            Force = force / 3;
            _r1.force += Force;
            _r2.force += Force;
            _r3.force += Force;
        }
    }
}