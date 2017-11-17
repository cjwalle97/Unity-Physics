using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoidScripts
{
    public class AgentFactory : MonoBehaviour
    {
        public int Count;
        public List<AgentBehaviour> agentBehaviours;
        public static List<Agent> agents;


        void Awake()
        {
            Create();
        }

        // Use this for initialization
        void Start()
        {
            GetBoids();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //Name: Create
        //Type: void
        //Protection: public 
        /*Description: A function of the type void that takes in no argument.
         It creates a loop that stops when the integer i is the same value as the Agent list agents Capacity
         It then creates a GameObject and attatches a behaviour to said GameObject.
         It then adds a Boid and a BoidBehaviour to the lists agents and agentBehaviours respectively.*/
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

        //Name: GetBoids
        //Type: List<Boids>
        //Protection: public 
        /*Description: Loops through the Boids in agents and adds them to a list result which is then returned.*/
        public static List<Boid> GetBoids()
        {
            List<Boid> result = new List<Boid>();
            foreach(Boid b in agents)
            {
                result.Add(b);
            }
            return result;
        }
    }
}