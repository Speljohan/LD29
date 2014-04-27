using UnityEngine;
using System.Collections;

public class AITest : MonoBehaviour
{

    private Rigidbody2D controller;
    public Vector2 speed = new Vector2(1, 1);
    private Vector2 moveTo = new Vector2(0, 0);
    // Use this for initialization
    private Vector2 moveDirection = new Vector2(1, 0);
    private Vector2 nextMoveDirection = new Vector2(0, 0);
    private bool paused = false;
    private bool hasTouchedNode = false;
    void Start()
    {
        this.controller = GetComponent<Rigidbody2D>();
        controller.gravityScale = 0;
        moveDirection = new Vector2(1, 0);
        print(moveDirection.x);

    }

    public void Pause()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
    }



    // Update is called once per frame
    void Update()
    {
        print("Hai, AIM A AITEST");
        // print("OIL");
        if (hasTouchedNode)
        {
            Vector2 goPos = gameObject.GetComponent<BoxCollider2D>().transform.position;
            if (controller.velocity.x == 1 && controller.velocity.y == 0)
            {
                if (goPos.x >= moveTo.x)
                {
                    moveDirection = nextMoveDirection;
                    print("IM MOVING YO");
                }
            }
            if (controller.velocity.x == -1 && controller.velocity.y == 0)
            {
                if (goPos.x <= moveTo.x)
                {
                    moveDirection = nextMoveDirection;
                }
            }
            if (controller.velocity.x == 0 && controller.velocity.y == 1)
            {
                if (goPos.y >= moveTo.y)
                {
                    moveDirection = nextMoveDirection;
                }
            }
            if (controller.velocity.x == 0 && controller.velocity.y == -1)
            {
                if (goPos.y <= moveTo.y)
                {
                    moveDirection = nextMoveDirection;
                }
            }

        }

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        hasTouchedNode = true;
        print("WE HIT OIL!");

        NodeRule node = otherCollider.gameObject.GetComponent<NodeRule>();

        Vector2 nodePos = node.GetComponent<BoxCollider2D>().size;
        Vector2 goHBp = gameObject.GetComponent<BoxCollider2D>().transform.position;
        if (controller.velocity.x == 1 && controller.velocity.y == 0)
        {
            moveTo = new Vector2(goHBp.x + nodePos.x, goHBp.y);
        }
        if (controller.velocity.x == -1 && controller.velocity.y == 0)
        {
            moveTo = new Vector2(goHBp.x - nodePos.x, goHBp.y);
        }
        if (controller.velocity.x == 0 && controller.velocity.y == 1)
        {
            moveTo = new Vector2(goHBp.x, goHBp.y + nodePos.y);
        }
        if (controller.velocity.x == 0 && controller.velocity.y == -1)
        {
            moveTo = new Vector2(goHBp.x, goHBp.y - nodePos.y);
        }

        // gameObject.transform.position = node.GetComponent<BoxCollider2D>().transform.position;
        nextMoveDirection = node.GetRandomTraversibleVector(controller.velocity);

    }

    void FixedUpdate()
    {
        if (paused)
        {
            controller.velocity = Vector2.zero;
            return;
        }
        controller.velocity = moveDirection;
        {
            controller.velocity = moveDirection;

        }
    }
}
