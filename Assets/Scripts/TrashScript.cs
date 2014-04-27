using UnityEngine;
using System.Collections;

public class TrashScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.E))
        {
            //Do dialogue "Hey I found some food";
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            go.GetComponent<PlayerScript>().food++;

        }
	}
}
