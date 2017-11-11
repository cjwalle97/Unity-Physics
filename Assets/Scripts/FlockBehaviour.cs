using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockBehaviour : MonoBehaviour
{
    public List<Boid> boidList;
    public List<Boid> neighbors;

	// Use this for initialization
	void Start ()
    {
        // Set boidList as the List of Agents in the AgentFactory
        foreach(Agent a in AgentFactory.agents)
        {
            boidList.Add(a as Boid);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 Dispersion(Boid b)
    {
        Vector3 force = new Vector3(0, 0, 0);
        return force;
    }
}
