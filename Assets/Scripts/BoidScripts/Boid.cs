using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : Agent
{
    public override bool Add_Force(float mag, Vector3 dir)
    {
        return true;
    }

    public override Vector3 Update_Agent(float deltaTime)
    {
        return new Vector3(0, 0, 0);
    }
}
