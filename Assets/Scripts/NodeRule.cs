using UnityEngine;
using System.Collections;

public class NodeRule : MonoBehaviour {

    public bool west, east, north, south;

    public int GetRandomTraversibleNode()
    {
        /*if (north) return new Vector2(0,1);
        if (west) return new Vector2(-1, 0);
        if (east) return new Vector2(1, 0);
        if (south) return new Vector2(0, -1);*/
        return 1;
    }
    public Vector2 GetRandomTraversibleVector(Vector2 vec)
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        int aL = 0;
        int iP = 0;

        if (north) aL++;
        if (west) aL++;
        if (east) aL++;
        if (south) aL++;

        Vector2[] vectors = new Vector2[aL];

        if (north)
        {
           vectors[iP] = new Vector2(0, 1);
           iP++;
        }
        if (west)
        {
            vectors[iP] = new Vector2(-1, 0);
            iP++;
        }

        if (east)
        {
            vectors[iP] =  new Vector2(1, 0);
            iP++;
        }
        if (south)
        {
            vectors[iP] = new Vector2(0, -1);
            iP++;
        }


        int iiiii = Random.Range(0, aL-1);
        print("NODE RANDOM FAGGOT " + iiiii);
        return vectors[iiiii];
    }
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("WE HIT gold!");
    }
}
