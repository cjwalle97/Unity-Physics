using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockBehaviour : MonoBehaviour
{
    public List<Boid> boidList;

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
}
