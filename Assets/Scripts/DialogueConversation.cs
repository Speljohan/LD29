using System.Collections.Generic;
using UnityEngine;

public class DialogueConversation
{

    public List<string> lines = new List<string>();
    public List<Sprite> mugshots = new List<Sprite>();

    public DialogueConversation Add(string line, Sprite mugshot)
    {
        lines.Add(line);
        mugshots.Add(mugshot);
        return this;
    }

    public int Count()
    {
        return lines.Count;
    }
}
