using UnityEngine;
using System.Collections;

public class TriggerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider target)
    {
        target.gameObject.BroadcastMessage("NewTarget");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
