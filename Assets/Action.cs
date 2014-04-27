using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
}
