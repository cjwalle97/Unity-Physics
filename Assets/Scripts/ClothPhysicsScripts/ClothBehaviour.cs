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
            AlignParticles();
            
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

        void CreateSpringDampers(GameObject go, Particle par1, Particle par2)
        {
            SpringDamperBehaviour spb = go.AddComponent<SpringDamperBehaviour>();
            spb._particle1 = par1;
            spb._particle2 = par2;
        }
        
        void AlignParticles()
        {
            for (int k = 0; k < _height; k++)
            {
                for (int i = 0; i < _width; i++)
                {
                    Vector3 newposition = new Vector3(i * 10, k * 10, 0.0f);
                    _particles[ i + (k * _width)].position = newposition;
                }
            }
        }
    }
}