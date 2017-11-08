using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Agent : ScriptableObject
{
    [SerializeField]
    protected float Mass;
    [SerializeField]
    protected Vector3 Velocity;
    [SerializeField]
    protected Vector3 Acceleration;
    [SerializeField]
    protected Vector3 Position;
    [SerializeField]
    protected float max_Speed;

    public Transform _owner;
    void Initialize(Transform owner)
    {
        Mass = 1;
        Velocity = Vector3.right;
        Acceleration = Vector3.right;
        Position = _owner.position;
    }

    // Update is called once per frame
    abstract public Vector3 Update_Agent(float deltaTime);
    abstract public bool Add_Force(float mag, Vector3 dir);
    
}
