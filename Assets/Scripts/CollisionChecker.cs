using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public List<AABB> AxisList;

    private int active;
    private List<AABB> ActiveList;
    private bool isColliding;

	// Use this for initialization
	void Start ()
    {
        active = 0;
        AxisList.Sort();
        ActiveList.Add(AxisList[active]);
	}
	
	// Update is called once per frame
	void Update ()
    {
        SortandSweep();
	}

    public void SortandSweep()
    {
        AABB check;
        for(int i = active + 1; i < AxisList.Capacity; i++)
        {
            check = AxisList[i];
            if(check.m_min.x >= ActiveList[active].m_min.x && check.m_min.x <= ActiveList[active].m_max.x)
            {
                ActiveList.Add(check);
                Debug.Log("Collision Occured");
                active += 1;
            }
            else
            {
                ActiveList.Remove(ActiveList[active]);
                active += 1;
                break;
            }
        }
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
