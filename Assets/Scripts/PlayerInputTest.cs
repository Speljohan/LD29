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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.activeObject != null)
            {
                activeObject.GetComponent<AITest>().BroadcastMessage("Pause");
                GameObject.FindGameObjectWithTag("Main").GetComponent<DialogueManager>().StartDialogue(DialogueGenerator.GeneratePositive(), activeObject);    
            }
        }
		float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

		GetComponent<CharacterController>().Move(new Vector3(x, y, 0));
	}
}
