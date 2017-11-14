using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : AgentBehaviour
{
    public Boid boid;
    public Transform owner;

    public void SetBoid(Agent b)
    {
        Vector3 RandomSpawn = new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));
        owner.position = RandomSpawn;
        agent = b;
        boid = agent as Boid;
        boid.Initialize(owner);
    }

    private void Start()
    {
        SetBoid(boid);
    }

    public void Update()
    {

    }

    public void LateUpdate()
    {
        transform.position = agent.Update_Agent(Time.deltaTime);
    }
    
}