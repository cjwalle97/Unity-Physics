using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Name: ComponentRemover
//Type: class inheriting from MonoBehaviour
//Description: Will take in a GameObject, display all the MonoBehaviours inside it,
//and then remove them if the user presses the Remove button
public class ComponentRemover : MonoBehaviour
{
    public List<MonoBehaviour> BehavioursList;
    public GameObject gameobject;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void GetList()
    {
        var ol = gameobject.GetComponents<MonoBehaviour>();
    }
}
