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
        if(otherCollider.gameObject.tag == "Player")
        { 
           // node = otherCollider.gameObject.GetComponent<NodeRule>();
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            go.GetComponent<PlayerScript>().food++;
            GameObject.FindGameObjectWithTag("Main").GetComponent<DialogueManager>().StartDialogue(DialogueGenerator.GeneratePositive(), gameObject);
            //Do dialogue "Thanks, your smile makes mer feel real.";
        }
    }
}
