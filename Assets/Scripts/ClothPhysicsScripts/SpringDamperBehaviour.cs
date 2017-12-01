using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClothPhysics
{
    public class SpringDamperBehaviour : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            var sd = new SpringDamper();
            var go1 = new GameObject("Particle 1");
            var pb1 = go1.AddComponent<ParticleBehaviour>();
            pb1._particle = sd._p1;
            var go2 = new GameObject("Particle 2");
            var pb2 = go2.AddComponent<ParticleBehaviour>();
            pb2._particle = sd._p2;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}