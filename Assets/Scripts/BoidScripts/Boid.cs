using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoidScripts
{
    public class Boid : Agent, IMoveable
    {
        //Name: Add_Force
        //Type: bool
        //Protection: public
        /*Description:*/
        public bool Add_Force(float mag, Vector3 dir)
        {
            return true;
        }

        //Name: Update_Agent
        //Type: Vector3
        //Protection: public 
        /*Description:*/
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