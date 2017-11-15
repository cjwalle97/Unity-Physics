using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicketScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerRigidBodyController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private float _speed;
        private List<Vector3> movementList;
        
        // Use this for initialization
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _speed = 3.0f;
        }

        // Update is called once per frame
        void Update()
        {
            var i = 0;
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            Vector3 input = new Vector3(h, 0, v);
            movementList[i] = input;
            i += 1;
            var acc = input;
            var vel = acc * Time.deltaTime;
            _rigidbody.velocity = vel;
        }

        public Vector3 QuickTurn(Vector3 velocity)
        {
            Vector3 temp = velocity * -1;
            _rigidbody.velocity = Vector3.zero;
            return temp;
        }
    }
    
}