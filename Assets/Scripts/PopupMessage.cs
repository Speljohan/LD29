using UnityEngine;
using System.Collections;

public class PopupMessage : MonoBehaviour {

    private string text;
    private Color colour;
    private float duration;

    private float currentTime;
    private float fadeTime;

    private GameObject obj;
    private GUIText guiText;

	// Use this for initialization
	void Start () {
	    
	}

    public void SetMessage(float x, float y, string text, Color colour, float duration, float fadeTime)
    {
        this.text = text;
        this.colour = colour;
        this.duration = duration;
        this.fadeTime = fadeTime;
        init();
    }

    void init ()
    {
        obj = new GameObject();
        guiText = obj.AddComponent<GUIText>();
        guiText.text = text;
        obj.transform.position = new Vector3(0, 0, 1);
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (colour.a <= 0)
        {
            Destroy(obj);
        }

        if (currentTime >= duration)
        {
            currentTime = 0;
            colour.a -= fadeTime;
            guiText.color = colour;
        }
	}
}
