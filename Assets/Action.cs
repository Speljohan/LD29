using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter!!!");
        other.gameObject.GetComponent<PlayerInputTest>().BroadcastMessage("Active", this);
    }

    void OnCollisionStay(Collision other)
    {
        Debug.Log("Stay!!!");
    }

    void OnCollisionExit(Collision other)
    {
        Debug.Log("Exit!!!");
        other.gameObject.GetComponent<PlayerInputTest>().BroadcastMessage("Inactive", this);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Vector2.Distance(transform.position, player.transform.position) <= 0.8f)
        {
            player.GetComponent<PlayerInputTest>().BroadcastMessage("Active", this.gameObject);
        }
        else
        {
            player.GetComponent<PlayerInputTest>().BroadcastMessage("Inactive", this.gameObject);
        }
	}

    float distanceTo(Vector3 src, Vector3 dst)
    {
        return Mathf.Atan2((src.x - dst.x),(src.y - dst.y));
    }
}
