using UnityEngine;
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

	// Use this for initialization

	void Start () {
        isRunning = false;
	}

    public bool IsInDialogue()
    {
        return isRunning;
    }

    public void StartDialogue(DialogueConversation conversation)
    {
        this.conversation = conversation;
        Init();
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

        GameObject cam = GameObject.FindGameObjectWithTag("GUI");

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

        mugshot_animator = cam.AddComponent<Animator>();
        mugshot_animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Sprites/changeMan_0");
        mugshot_animator.Play("TestAni");

        audio = gui.AddComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>("Sound/conversation_noise");
    }

    public void Destroy()
    {
        Destroy(gui);
        Destroy(text);
        Destroy(background);
        Destroy(mugshot_r);
        Destroy(audio);
        isRunning = false;
    }

    public void RenderNextFrame()
    {
        textScroller.SetText(conversation.lines[currentConversation], text);
        mugshot_r.sprite = conversation.mugshots[currentConversation];
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