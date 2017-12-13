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
        private int _width = 5;
        private int _height = 5;

        // Use this for initialization
        void Start()
        {
            _objects = new List<GameObject>();
            _particles = new List<Particle>();
            _springdamperbehaviours = new List<SpringDamperBehaviour>();
            CreateParticles();
            for (int i = 0; i < _height - 1; i++)
            {
                CreateRow(i);
            }
            for (int r = 0; r < _width - 1; r++)
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
            var go = new GameObject();
            go.name = string.Format("{0} {1}", "SpringDamper", row);
            var dmp = go.AddComponent<SpringDamperBehaviour>();
            for (int i = 0; i < _width; i++)
            {
                dmp._particle1 =  _particles[i + (5 * row)];
                dmp._object1 = _objects[i + (5 * row)];
                dmp._particle2 = _particles[i + 2 + (5 * row)];
                dmp._object2 = _objects[i + 2 + (5 * row)];
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
            for(int i = 0; i < _particles.Capacity -1; i++)
            {
                _objects[i].transform.position = _particles[i].position;
            }
        }
    }
}