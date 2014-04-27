using UnityEngine;
using System.Collections;

public class BambScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            



        }


    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        go.GetComponent<PlayerScript>().food++;
        //Do dialogue "Thanks, your smile makes mer feel real.";
    }
}
