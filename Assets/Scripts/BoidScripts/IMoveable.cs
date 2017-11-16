using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoidScripts
{
    public interface IMoveable
    {
        Vector3 Update_Agent(float dt);
        bool Add_Force(float mag, Vector3 dir);
    }
}