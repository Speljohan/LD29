using UnityEngine;
using System.Collections;

public class PlayerInputTest : MonoBehaviour {

	float moveSpeed = 3f;

    public int abstinence, hunger, cold;

    GameObject activeObject;

    private GameObject main;
	// Use this for initialization
	void Start () {
        main = GameObject.FindGameObjectWithTag("Main");
	}

    void Active(GameObject obj)
    {
        this.activeObject = obj;
       
    }

    void Inactive(GameObject obj)
    {
        this.activeObject = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (main.GetComponent<DialogueManager>().IsInDialogue()) return;
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Active!!" + this.activeObject);
        }
		float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

		GetComponent<CharacterController>().Move(new Vector3(x, y, 0));
	}
}
