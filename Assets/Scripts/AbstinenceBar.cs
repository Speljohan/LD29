using UnityEngine;
using System.Collections;

public class AbstinenceBar : MonoBehaviour {

    float curSize = 5f;
    Vector3 veco;
    public Vector3 origin;
    public GameObject owner;
    public PlayerScript ps;

	// Use this for initialization

	void Start () {
        veco = new Vector3(curSize, 5f, 1f);
        gameObject.transform.localScale = veco;
        ps = owner.GetComponent<PlayerScript>();
        
	}
	
	// Update is called once per frame
	void Update () {
        curSize = ps.abstinence;
        print("UUU CURSICIEÅF: " + curSize);
        if(curSize <= 1)
        {
            curSize = 1;
        }
      Vector3 veco = new Vector3(curSize/100 ,1, 1);
      gameObject.transform.localScale = veco;
	}
}
