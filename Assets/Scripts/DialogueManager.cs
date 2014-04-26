using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {

    public GameObject wu;
    public GameObject wu2;
	// Use this for initialization
	void Start () {
        print("WOOOOO");
        wu.renderer.enabled = false;
        wu2.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("h"))
        {
            print("h PRESS");
            wu.renderer.enabled = !wu.renderer.enabled;
            wu2.renderer.enabled = !wu2.renderer.enabled;

        }
          
	}
}