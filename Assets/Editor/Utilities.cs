using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Utilities
{
    public class AABB
    {
        public Vector2 m_min;
        public Vector2 m_max;

        public AABB(Vector2 min, Vector2 max)
        {
            m_min = min; m_max = max;
        }

    }

    public bool TestOverlap(AABB a, AABB b)
    {
        bool xCollide = false;
        if(a.m_min.x <= b.m_max.x && a.m_min.x >= b.m_min.x)
        {
            xCollide = true;
        }
        if (xCollide == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

