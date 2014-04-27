using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {

    private CharacterController controller;
    private Transform transform;

    public float speed = 2.0f;

    private List<GameObject> nodes;

    private Vector3 lastPosition;
    private Vector3 destination;

	// Use this for initialization
	void Start () {
        this.controller = GetComponent<CharacterController>();
        //controller.radius = 1;
        //controller.height = 1;
        this.transform = GetComponent<Transform>();
        this.nodes = new List<GameObject>();
        nodes.AddRange(GameObject.FindGameObjectsWithTag("MovementNode"));
        int targetNode = Random.Range(0, nodes.Count);
        this.destination = DirToVector(NextNode(nodes[targetNode].GetComponent<NodeRule>())).normalized;
        this.transform.position = destination;

    }

    void NewTarget()
    {
        //transform.position = destination;
        destination = DirToVector(NextNode(nodes[Random.Range(0, nodes.Count)].GetComponent<NodeRule>())).normalized;
        Debug.Log("NEW: " + destination);
    }

    public int NextNode(NodeRule rule)
    {
        int dest = Random.Range(0, 3);
        switch (dest)
        {
            case 0:
                if (rule.north) return 0;
                break;
            case 1:
                if (rule.west) return 1;
                break;
            case 2:
                if (rule.east) return 2;
                break;
            case 3:
                if (rule.south) return 3;
                break;
        }
        return rule.GetRandomTraversibleNode();
    }

    public Vector3 DirToVector(int i)
    {
        switch (i)
        {
            case 0:
                return new Vector3(0, -1, 0);
                break;
            case 1:
                return new Vector3(-1, 0, 0);
                break;
            case 2:
                return new Vector3(1, 0, 0);
                break;
            case 3:
                return new Vector3(0, 1, 0);
                break;
        }
        return new Vector3(-1, -1, 0);
    }

    public void Update()
    {

        if (transform.position == lastPosition)
        {
            controller.Move(new Vector3(destination.x * Time.deltaTime * speed, destination.y * Time.deltaTime * speed, 0));
        }
        lastPosition = transform.position;
    }
}
