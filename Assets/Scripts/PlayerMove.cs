using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    private Vector2 mover;
    
    private Rigidbody2D contr;
    public float moveSpeed = 4;
	// Use this for initialization
	void Start () {
        contr = GetComponent<Rigidbody2D>();
        contr.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //float y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        // 4 - Movement per direction
        mover = new Vector2(
          moveSpeed * inputX,
          moveSpeed * inputY);
        
	}
    void FixedUpdate()
    {
        rigidbody2D.velocity = mover;
    }
}
