using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoidScripts
{
    public class FlockBehaviour : MonoBehaviour
    {
        public List<Boid> boidList;
        public List<Boid> neighbors;

        private Vector3 _mCohesion;
        private Vector3 _mDispersion;
        private Vector3 _mAlignment;

        // Use this for initialization
        void Start()
        {
            // Set boidList as the List of Agents in the AgentFactory
            foreach (Agent a in AgentFactory.agents)
            {
                boidList.Add(a as Boid);
                neighbors.Add(a as Boid);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        private Vector3 Cohesion(Boid bj)
        {
            float n = neighbors.Capacity;
            Vector3 pcj = Vector3.zero;
            foreach (Boid bi in neighbors)
            {
                if (bi != bj)
                {
                    pcj = pcj + bi.position;
                }
            }
            pcj = pcj / (n - 1);
            return pcj;
        }

        private Vector3 Dispersion(Boid bj)
        {
            Vector3 force = Vector3.zero;
            foreach (Boid bi in neighbors)
            {
                if (bi != bj)
                {
                    Vector3 distance = bi.position - bj.position;
                    if (distance.x < 100 || distance.y < 100 || distance.z < 100)
                    {
                        force = force - distance;
                    }
                }
            }
            return force;
        }

        private Vector3 Alignment(Boid bj)
        {
            float n = neighbors.Capacity;
            Vector3 pvj = Vector3.zero;
            foreach (Boid bi in neighbors)
            {
                if (bi != bj)
                {
                    pvj = pvj + bi.velocity;
                }
            }
            pvj = (pvj - bj.velocity) / 8;
            return pvj;
        }
    }
}