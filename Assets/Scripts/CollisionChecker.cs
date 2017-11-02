﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public List<AABB> AxisList;

    private List<AABB> ActiveList;

	// Use this for initialization
	void Start ()
    {
        AxisList.Sort();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public bool TestOverlap(AABB a, AABB b)
    {
        bool xCollide = false;
        bool yCollide = false;
        if (a.m_min.x <= b.m_max.x && a.m_min.x >= b.m_min.x)
        {
            xCollide = true;
        }
        if (a.m_min.y <= b.m_max.y && a.m_min.y >= b.m_min.y)
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