using UnityEngine;

namespace ClothPhysics
{
    public class ParticleBehaviour : MonoBehaviour
    {
        public Particle _particle;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _particle.ApplyForce();
        }
        
    }
}