using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Agent : ScriptableObject
{
    [SerializeField]
    protected float mass;
    [SerializeField]
    protected Vector3 acceleration;
    [SerializeField]
    protected float max_Speed;
    [SerializeField]
    public Vector3 velocity;
    [SerializeField]
    public Vector3 position;

    public void Initialize(Transform owner)
    {
        max_Speed = 10;
        mass = 1;
        velocity = Vector3.right;
        acceleration = Vector3.right;
        position = owner.position;
    }

    // Update is called once per frame
    abstract public Vector3 Update_Agent(float deltaTime);
    abstract public bool Add_Force(float mag, Vector3 dir);
}
