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
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        void CreateParticles()
        {
            for (int i = 0; i < (_width * _height) * 2; i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var par = new Particle();
                go.name = string.Format("{0} {1}", "Particle: ", i);
                _objects.Add(go);
                _particles.Add(par);
            }
        }

        void CreateSpringDampers(GameObject go, Particle par1, Particle p2)
        {
            SpringDamperBehaviour spb = go.AddComponent<SpringDamperBehaviour>();
        }
    }
}