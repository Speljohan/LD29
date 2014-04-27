using UnityEngine;
using System.Collections;

public class AbstinenceBar : MonoBehaviour {

    public GameObject ab;
    float curSize = 1f;
    Vector3 veco;
	// Use this for initialization
	void Start () {
        veco = new Vector3(curSize, 5f, 1f);
          ab.transform.localScale = veco;
	}
	
	// Update is called once per frame
	void Update () {
      curSize -= Time.time * 0.0001f;
        if(curSize <= 0.001f)
        {
            curSize = 0.001f;
        }
      Vector3 veco = new Vector3(curSize, 5f, 1f);
      ab.transform.localScale = veco;
	}
}
