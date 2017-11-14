using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFactory : MonoBehaviour
{
    public int Count;
    public static List<Agent> agents;
    public List<AgentBehaviour> agentBehaviours;

    void Awake()
    {
        Create();
    }

    // Use this for initialization
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Create")]
    public void Create()
    {
        agents = new List<Agent>();
        agentBehaviours = new List<AgentBehaviour>();
        agents.Capacity = Count;
        agentBehaviours.Capacity = Count;
        for (int i = 0; i < Count; i++)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.SetParent(transform);
            go.name = string.Format("{0} {1}", "Agent: ", i);
            
            var behaviour = go.AddComponent<BoidBehaviour>();
            behaviour.owner = go.transform;

            var boid = ScriptableObject.CreateInstance<Boid>();
            

            agents.Add(boid);
            agentBehaviours.Add(behaviour);
            behaviour.SetBoid(boid);
        }
    }

}
