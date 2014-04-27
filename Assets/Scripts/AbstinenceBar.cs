using UnityEngine;
using System.Collections;

public class AbstinenceBar : MonoBehaviour {

    float curSize = 5f;
    Vector3 veco;
    public Vector3 origin;
    public GameObject owner;
	// Use this for initialization

	void Start () {
        veco = new Vector3(curSize, 5f, 1f);
        gameObject.transform.localScale = veco;
        
	}
	
	// Update is called once per frame
	void Update () {
      curSize -= Time.time * 0.0001f;
        if(curSize <= 0.001f)
        {
            curSize = 0.001f;
        }
      Vector3 veco = new Vector3(curSize, 5f, 1f);
      gameObject.transform.localScale = veco;
	}
}
