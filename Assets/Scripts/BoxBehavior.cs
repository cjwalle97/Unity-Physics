using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    public int BlockNum;
    public GameObject Block;

    private List<GameObject> BlockList;

	// Use this for initialization
	void Start ()
    {
        CreateBoxes(BlockNum);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void CreateBoxes(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(Block);
        }
    }
    
    public void AttachAABB()
    {

    }
}
