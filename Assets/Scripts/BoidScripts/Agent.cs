using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoidScripts
{
    abstract public class Agent : ScriptableObject
    {
        [SerializeField]
        protected float mass;
        [SerializeField]
        protected Vector3 acceleration;
        [SerializeField]
        protected float max_Speed;
        [SerializeField]
        protected Vector3 force;
        [SerializeField]
        public Vector3 velocity;
        [SerializeField]
        public Vector3 position;

        //Name: Initialize
        //Type: void
        //Protection: public
        /*Description:*/
        public void Initialize(Transform owner)
        {
            max_Speed = 10;
            mass = 1;
            velocity = Vector3.right;
            acceleration = Vector3.right;
            position = owner.position;
        }

    }
}