using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoidScripts
{
    public class Boid : Agent, IMoveable
    {
        //Name:
        //Type:
        //Protection:
        //Description:
        public bool Add_Force(float mag, Vector3 dir)
        {
            return true;
        }

        //Name:
        //Type:
        //Protection:
        //Description:
        public Vector3 Update_Agent(float dt)
        {
            acceleration = force / mass;
            velocity += acceleration * dt;
            velocity = Vector3.ClampMagnitude(velocity, max_Speed);
            position += velocity * dt;
            return position;
        }
    }
}