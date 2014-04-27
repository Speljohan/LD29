using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
    GameObject[] nodes;
    private float spawnTimer = 0;
    public float spawnTime = 5;
	// Use this for initialization
	void Start () {
        nodes = GameObject.FindGameObjectsWithTag("EnterNode");
	}
	
	// Update is called once per frame
	void Update () {
        print("Number of entry nodes: " + nodes.Length);
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            spawnTimer -= spawnTime;
            spawnNpc();
        }
	}

    void spawnNpc()
    {
        print("Tryng to spawn");
        Random.seed = (int)System.DateTime.Now.Ticks;
        GameObject spawnNode = nodes[Random.Range(0, nodes.Length - 1)];
        GameObject npc = Instantiate(Resources.Load("Prefabs/actor_lady")) as GameObject;
        BoxCollider2D boxCol = npc.GetComponent("BoxCollider2D") as BoxCollider2D;
        boxCol.transform.position = spawnNode.transform.position;
        print("Has spawned NPC");
        
    }
}
