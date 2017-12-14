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
        public int _width;
        public int _height;

        // Use this for initialization
        void Start()
        {
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
        }

        // Update is called once per frame
        void Update()
        {
            ObjectPositioning();
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
    }
}