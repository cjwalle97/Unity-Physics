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
            var go1 = new GameObject();
            var pb1 = go1.AddComponent<ParticleBehaviour>();
            pb1.particle = sd._p1;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}