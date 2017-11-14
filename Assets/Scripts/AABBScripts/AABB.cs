using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AABB")]

public class AABB : ScriptableObject
{
    public Vector2 m_min;
    public Vector2 m_max;
}