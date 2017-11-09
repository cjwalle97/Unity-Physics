using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFactory : MonoBehaviour
{
    public int Count;
    public static List<Agent> agents;
    public List<AgentBehavior> agentBehaviors;

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
        agentBehaviors = new List<AgentBehavior>();
        agents.Capacity = Count;
        agentBehaviors.Capacity = Count;
        for (int i = 0; i < Count; i++)
        {
            var go = new GameObject();
            go.transform.SetParent(transform);
            go.name = string.Format("{0} {1}, Agent: ", i);

            var behavior = go.AddComponent<BoidBehavior>();

            var boid = ScriptableObject.CreateInstance<Boid>();

            agents.Add(boid);
            agentBehaviors.Add(behavior);
            behavior.SetBoid(boid);
        }
    }

    [ContextMenu("Destroy")]
    public void Destroy()
    {

    }
}
