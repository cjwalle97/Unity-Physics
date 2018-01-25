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

        // Use this for initialization
        void Start()
        {

            //CreateParticles();
            //CreateObjects();
            _damper = new SpringDamper(_particle1, _particle2, 3.0f, 3.0f, 15.0f);
            _damper.ApplyGravity(1.0f);
        }

        // Update is called once per frame
        void Update()
        {
            _object1.transform.position = _particle1.position;
            _object2.transform.position = _particle2.position;
        }

        void FixedUpdate()
        {
            _damper.CalculateForce();
        }

        void CreateObjects()
        {
            _object1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _object1.name = "Particle 1";
            var pb1 = _object1.AddComponent<ParticleBehaviour>();
            pb1._particle = _particle1;

            _object2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            _object2.name = "Particle 2";
            var pb2 = _object2.AddComponent<ParticleBehaviour>();
            pb2._particle = _particle2;
        }

        void CreateParticles()
        {
            _particle1 = new Particle();
            _particle1.position = Vector3.zero;
            _particle1.locked = false;

            _particle2 = new Particle();
            _particle2.position = new Vector3(15, 0, 0);
            _particle2.locked = false;
        }
    }

}