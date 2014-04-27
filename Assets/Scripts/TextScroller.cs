using UnityEngine;
using System.Collections;

public class TextScroller : MonoBehaviour {

    private string text;
    private GUIText gText;
    private int currentIndex;
    private string substring;
    private float scrollInterval = 0.05f;
    private float currentTime;
    private AudioClip clip;

    private bool isRunning;

	// Use this for initialization
	void Start () {
	}

    public void SetText(string text, GUIText gText)
    {
        isRunning = false;
        this.text = text;
        this.gText = gText;
        this.currentIndex = 0;
        this.currentTime = 0;
        isRunning = true;
    }

    string GetSubstring()
    {
        return substring;
    }

	// Update is called once per frame
	void Update () {
        if (isRunning)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= scrollInterval)
            {
                currentIndex++;
                currentTime = 0;
                if (currentIndex >= text.Length)
                {
                    substring = substring + "\n (C to continue)";
                    gText.text = substring;
                    isRunning = false;
                    GameObject.FindGameObjectWithTag("Main").audio.volume = 0.5f;
                    return;
                }
                substring = text.Substring(0, currentIndex);
                GetComponent<AudioSource>().Play();
                GameObject.FindGameObjectWithTag("Main").audio.volume = 0.15f;
                gText.text = substring;
            }
        }
	}
}
