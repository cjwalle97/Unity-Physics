using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public AABB AABBconfig;
    public AABB test;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TestOverlap(test);
	}

    public bool TestOverlap(AABB other)
    {
        bool xCollide = false;
        bool yCollide = false;
        if (AABBconfig.m_min.x <= other.m_max.x && AABBconfig.m_min.x >= other.m_min.x)
        {
            xCollide = true;
        }
        if (AABBconfig.m_min.y <= other.m_max.y && AABBconfig.m_min.y >= other.m_min.y)
        {
            yCollide = true;
        }
        if (xCollide == true && yCollide == true)
        {
            Debug.Log("Collision occured");
            return true;
        }
        else
        {
            return false;
        }
    }
}
