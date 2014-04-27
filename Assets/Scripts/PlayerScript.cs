using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int money = 0;
    public int amtAlc = 0;
    public int food = 0;
    public int abstinence = 100;
    public int hunger = 100;

    public int timerMax = 1;
    public int abGain = 100;
    private float curTimer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.O))
        {
            drinkAlc();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            eatFood();
        }
        curTimer += Time.deltaTime;
        if(curTimer >= timerMax)
        {
            curTimer -= timerMax;
            abstinence -= abGain;
        }
        
	}

    public void eatFood()
    {
        food--;
        hunger += 50;
    }
    public void drinkAlc()
    {
        amtAlc--;
        abstinence += 50;
    }
}
