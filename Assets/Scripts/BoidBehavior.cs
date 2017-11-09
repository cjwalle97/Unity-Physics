using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehavior : AgentBehavior
{
    public Boid boid;

    public void SetBoid(Agent b)
    {
        agent = b;
        boid = agent as Boid;
    }

    private void Start()
    {

    }

    public void Update()
    {

    }
    public void LateUpdate()
    {
        //transform.position = agent.Update_Agent();
    }
    
}
