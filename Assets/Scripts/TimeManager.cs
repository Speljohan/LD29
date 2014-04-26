using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public float dayHours;
    private float curTime;

	// Use this for initialization
	void Start () {
        curTime = dayHours;
	}
	
	// Update is called once per frame
	void Update () {
        curTime -= Time.deltaTime;
        print(curTime);
        if(curTime < 0)
        {
            
        }
	}
}
