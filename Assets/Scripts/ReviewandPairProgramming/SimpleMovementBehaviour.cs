using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Goal: To get a GameObject to move in one direction until it reaches a certain point.
It will then begin moving in the opposite direction until it reaches the second point.
It will continue doing this so long as the behaviour is active.*/

[AddComponentMenu("PairProgramming/Scripts/SimpleMovementBehaviour")]
public class SimpleMovementBehaviour : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    [SerializeField]
    private GameObject prefab;

    [ContextMenu("Create")]
    public void Create()
    {
        var go = Instantiate<GameObject>(prefab);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.transform.rotation = Quaternion.identity;
    }

    [ContextMenu("ExtensionCreate")]
    public void ExtensionCreate()
    {
        var go = Instantiate<GameObject>(prefab);
        go.transform.SetParent(transform);
        go.transform.Reset();
    }

    public void MoveTo(Vector3 destination)
    {
        var dir = destination - transform.position;
        var spd = 3.0f;
        var mov = dir * spd;
        transform.position += mov;
    }

    private void Start()
    {
        ExtensionCreate();
    }

    private void Update()
    {
        MoveTo(pointA.position);
    }
}

static public class Extensions
{
    static public void Reset(this Transform t)
    {
        t.position = Vector3.zero;
        t.localScale = Vector3.one;
        t.rotation = Quaternion.identity;
    }
}
