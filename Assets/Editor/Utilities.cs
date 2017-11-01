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
        bool yCollide = false;
        if(a.m_min.x <= b.m_max.x && a.m_min.x >= b.m_min.x)
        {
            xCollide = true;
        }
        if(a.m_min.y <= b.m_max.y && a.m_min.y >= b.m_min.y)
        {
            yCollide = true;
        }
        if (xCollide == true && yCollide == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

