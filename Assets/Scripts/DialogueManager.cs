﻿using UnityEngine;
using System.Collections;

public class DialogueManager : MonoBehaviour {

    private bool isRunning;
    private DialogueConversation conversation;
    private int currentConversation = 0;

    private GameObject gui;
    private GUIText text;
    private TextScroller textScroller;
    private GameObject background;
    private SpriteRenderer background_r;
    private SpriteRenderer mugshot_r;
    private Animator mugshot_animator;
    private AudioSource audio;
    private GameObject cam;
    private GameObject target;

    private bool initialised;

	// Use this for initialization

	void Start () {
        isRunning = false;
        initialised = false;
	}

    public bool IsInDialogue()
    {
        return isRunning;
    }

    public void StartDialogue(DialogueConversation conversation, GameObject target)
    {
        this.target = target;
        this.conversation = conversation;
        currentConversation = 0;
        if (!initialised)
        {
            Init();
            initialised = true;
        }
        gui.SetActive(true);
        cam.SetActive(true);
        RenderNextFrame();
        isRunning = true;
    }

    public void Init()
    {
        gui = new GameObject("TextRenderer");
        text = gui.AddComponent<GUIText>();

        text.font = Resources.Load<Font>("Fonts/Pixel-Noir");
        text.fontSize = 15;
        text.color = Color.black;
        text.transform.position = new Vector3(0.2f, 0.1f, 1f);

        textScroller = gui.AddComponent<TextScroller>();

        cam = GameObject.FindGameObjectWithTag("GUI");

        background = new GameObject("background");
        background.transform.parent = cam.transform;
        background_r = background.AddComponent<SpriteRenderer>();
        background_r.sprite = LoadFromSheet("Sprites/character_0", "dialogue_background");
        background_r.sortingOrder = 3;
        background_r.transform.localScale = new Vector3(90f, 6f, 1);
        background_r.transform.position = new Vector3(-3.7f, 0, 0);
        background.transform.localPosition = new Vector3(0, 0, 0);



        mugshot_r = cam.AddComponent<SpriteRenderer>();
        mugshot_r.sortingOrder = 4;
        mugshot_r.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        cam.transform.localPosition = new Vector3(-7f, -3f, 0f);
        if (currentConversation == 0)
        {
            mugshot_r.enabled = true;
            mugshot_animator = cam.AddComponent<Animator>();
            mugshot_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Sprites/changeMan_1");
            mugshot_animator.Play("Bum_mugshot");
        }
        else
        {
            mugshot_r.enabled = false;
            mugshot_animator.enabled = false;
        }

        audio = gui.AddComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("Sound/conversation_noise");
    }

    public void Destroy()
    {
        gui.SetActive(false);
        GameObject.FindGameObjectWithTag("GUI").SetActive(false);
        target.GetComponent<AITest>().BroadcastMessage("Resume");

        isRunning = false;
    }

    public void RenderNextFrame()
    {
        textScroller.SetText(conversation.lines[currentConversation], text);
        if (currentConversation == 0)
        {
            mugshot_r.enabled = true;
            mugshot_animator.enabled = true;
            mugshot_r.sprite = conversation.mugshots[currentConversation];
        }
        else
        {
            mugshot_r.enabled = false;
            mugshot_animator.enabled = false;
        }
    }

    public static Sprite LoadFromSheet(string path, string name)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        foreach (Sprite s in sprites) {
            if (s.name == name) return s;
        }
        return null;
    }
	
	// Update is called once per frame
	void Update () {
        if (isRunning)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                currentConversation++;
                if (currentConversation >= conversation.lines.Count)
                {
                    Destroy();
                    return;
                }
                RenderNextFrame();
            }
        }
	}
}