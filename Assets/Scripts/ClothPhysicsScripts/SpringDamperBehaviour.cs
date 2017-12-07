﻿using System.Collections;
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
            _damper = new SpringDamper(_particle1, _particle2, 1.0f, 1.0f, 5.0f);
            _pb1 = _object1.AddComponent<ParticleBehaviour>();
            _pb1._particle = _damper._p1;
            
            var go2 = new GameObject("Particle 2");
            _pb2 = _object2.AddComponent<ParticleBehaviour>();
            _pb2._particle = _damper._p2;
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}