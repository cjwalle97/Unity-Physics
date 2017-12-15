using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class SpringDamperBehaviour : MonoBehaviour
    {
        public Particle _particle1;
        public Particle _particle2;
        public GameObject _object1;
        public GameObject _object2;

        private SpringDamper _damper;
        private ParticleBehaviour _pb1;
        private ParticleBehaviour _pb2;

        // Use this for initialization
        void Start()
        {
            //CreateObjects();
            //CreateParticles();
            _damper = new SpringDamper(_particle1, _particle2, 0.5f, 1.0f);
            _pb1._particle = _damper._p1;
            _pb2._particle = _damper._p2;
        }

        // Update is called once per frame
        void Update()
        {
        //    _object1.transform.position = _particle1.position;
        //    _object2.transform.position = _particle2.position;
            _damper.CalculateForce();
        }

        void CreateObjects()
        {
            _object1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _object1.name = "Particle 1";
            
            _object2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _object2.name = "Particle 2";
            
        }

        void CreateParticles()
        {
            _particle1 = new Particle();
            _particle1.position = Vector3.zero;

            _particle2 = new Particle();
            _particle2.position = new Vector3(10, 0, 0);

        }
    }
    
}