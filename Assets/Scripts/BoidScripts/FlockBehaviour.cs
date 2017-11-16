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
            //for each Agent a in the list Agent in the static class AgentFactory 
            foreach (Agent a in AgentFactory.agents)
            {
                //Add to the list of Boids boidList the Agent a as a Boid. 
                boidList.Add(a as Boid);
                //Add to the list of Boids, neighbors, the Agent a as a Boid.
                neighbors.Add(a as Boid);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }


        //Name: Cohesion
        //Type: Vector3
        //Protection: private
        /*Description: a function of the type Vector3 that takes in the argument Boid bj 
         * and returns the Vector3 pcj*/
        private Vector3 Cohesion(Boid bj)
        {
            /* variable of type float, n is assigned the value the function 
             * Capacity called by the Boid List neighbors.*/
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

        //Name: Dispersion
        //Type: Vector3
        //Protection: private
        /*Description: a function of the type Vector3 that takes in the argument Boid bj
         * and returns the Vector3 c*/
        private Vector3 Dispersion(Boid bj)
        {
            Vector3 c = Vector3.zero;
            foreach (Boid bi in neighbors)
            {
                if (bi != bj)
                {
                    Vector3 distance = bi.position - bj.position;
                    if (distance.x < 100 || distance.y < 100 || distance.z < 100)
                    {
                        c = c - distance;
                    }
                }
            }
            return c;
        }

        //Name: Alignment
        //Type: Vector3
        //Protection: private
        /*Description: a function of the type Vector3 that takes in the argument boid bj 
         * and returns the Vector3 pvj*/
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