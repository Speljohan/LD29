using UnityEngine;
using System.Collections;
using System.Linq;

public class Main : MonoBehaviour {



	// Use this for initialization
	void Start () {
        //CreateRandomNpc();
        //Sprite s = Resources.Load<Sprite>("Sprites/changeMan");

        /*DialogueConversation d = new DialogueConversation().Add("Hai der!", s).
            Add("Why won't anyone communicate with me? =( ", s).
            Add("Stop being so mean!", s).
            Add("I'll tell my mom on you!", s);

        GetComponent<DialogueManager>().StartDialogue(d);*/
        
	}

    void CreateRandomNpc()
    {
        GameObject obj = new GameObject();
        obj.tag = "NPC";
        SpriteRenderer r = obj.AddComponent<SpriteRenderer>();
        r.sprite = Resources.Load<Sprite>("Sprites/character_0");
        r.sortingOrder = 1;
        CharacterController cc = obj.AddComponent<CharacterController>();
        AI ai = obj.AddComponent<AI>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject obj = GameObject.FindGameObjectWithTag("GUI");
            PopupMessage msg = obj.AddComponent<PopupMessage>();
            msg.SetMessage(0, 0, "FOO", Color.red, 500, 0.1f);
        }
	}
}
