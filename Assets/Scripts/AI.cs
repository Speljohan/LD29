using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {

    private CharacterController controller;
    private Transform transform;

    public float speed = 2.0f;

    public List<GameObject> nodes = new List<GameObject>();
    private int currentIndex;
    private bool finished = false;

    private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
        this.controller = GetComponent<CharacterController>();
        controller.radius = 0;
        controller.height = 0;
        this.transform = GetComponent<Transform>();
        transform.position = new Vector3(-4f, 0.2f, 1);
        this.currentIndex = 0;
        //nodes = new List<GameObject>();
    }

    public void Next()
    {
        currentIndex++;
    }

    public void Update()
    {
        if (currentIndex >= nodes.Count)
        {
            return;
        }

        GameObject node = nodes[currentIndex];

        Transform targetPosition = node.GetComponent<Transform>();

        if ((transform.position - targetPosition.position).magnitude < 0.1f)
        {
            Next();
        }
        else
        {
            if (transform.position == lastPosition)
            {
                Vector3 direction = (targetPosition.position - transform.position).normalized;

                controller.Move(new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0));
            }
            lastPosition = transform.position;
        }
    }
}
