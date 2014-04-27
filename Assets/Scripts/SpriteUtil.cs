using UnityEngine;
using System.Collections;

public class SpriteUtil : MonoBehaviour {

    public static Sprite GetSheetSprite(string name)
    {
        return null;
    }

    public static Sprite GetMugshot(string name)
    {
        return LoadFromSheet("Sprites/bum_0", "changeMan_0");
    }

    public static Sprite GetHoboMugshot()
    {
        return LoadFromSheet("Sprites/bum_0", "changeMan_0");
    }

    private static Sprite LoadFromSheet(string path, string name)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        foreach (Sprite s in sprites) {
            if (s.name == name) return s;
        }
        return null;
    }
}
