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
        //transform.position = agent.Update_Agent();
    }

    //public Vector3 Seperation(Boid b)
    //{
    //    Vector3 force = new Vector3(0, 0, 0);
    //    return force;
    //}
}