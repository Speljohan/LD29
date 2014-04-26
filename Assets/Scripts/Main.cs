using UnityEngine;
using System.Collections;
using System.Linq;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CreateRandomNpc();
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
        
	}
}
