using UnityEngine;
using System.Collections;

public class PopupMessage : MonoBehaviour {

    private string text;
    private Color colour;
    private float duration;

    private float currentTime;
    private float fadeTime;

    private GUIText guiText;
    private GameObject obj;

	// Use this for initialization
	void Start () {
	    
	}

    public void CreateMessage(float x, float y, string text, Color colour, float duration, float fadeTime)
    {
        this.text = text;
        this.colour = colour;
        this.duration = duration;
        this.fadeTime = fadeTime;
        Init();
    }

    void Init ()
    {
        obj = new GameObject("message");
        guiText = obj.AddComponent<GUIText>();
        guiText.text = text;
        guiText.font = Resources.Load<Font>("Fonts/Pixel-Noir");
        guiText.fontSize = 15;
        guiText.color = Color.black;
        guiText.color = colour;
        guiText.transform.position = new Vector3(-0.48f, -0.62f, 0f);


        obj.transform.position = new Vector3(1f, 1f, 0f);

    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if (colour.a <= 0)
        {
            Destroy(obj);
            return;
        }

        if (currentTime >= duration)
        {
            currentTime = 0;
            //colour.a -= fadeTime;
            guiText.color = colour;
        }
	}
}
