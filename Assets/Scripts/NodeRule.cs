using UnityEngine;
using System.Collections;

public class NodeRule : MonoBehaviour {

    public bool west, east, north, south;

    public int GetRandomTraversibleNode()
    {
        if (north) return 0;
        if (west) return 1;
        if (east) return 2;
        if (south) return 3;
        return 0;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
