using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEditor;
using System;

class DialogueGenerator
{
    private static String[] bum_lines = new String[] { "Spare change please? ", 
        "Help a poor man out with a dollar? ", 
        "You got dough? ", 
        "Need money for food. " };

    private static String[] actor_positive = new String[] { "Aw, you poor man, here you go. ", 
        "What's this world coming to... ", 
        " Don't worry, always glad to help " };

    private static String[] actor_neutral = new String[] { "This goes aganist my better judgement, but here you go. ", 
        "I really shouldn't, you people ought to fix your problems, but unfortunately i have a consciousness. " };

    private static String[] actor_negative = new String[] { "Away with thee, dirty bum! ", 
        "Leave me alone and take your stench with you! ", 
        "How rude, get a job! " };

    private static String[] actor_police0 = new String[] { "Begging is forbidden here. Leave at once, or you'll suffer the consequences! ",
        "Move along, you know the rules...", "Get out of here before i'm forced to take action! "};

    private static String[] actor_police1 = new String[] { "You asked for it pal! ", "One knuckle sandwich coming up! ", " I warned you, but you just didn't listen... " };


    public static DialogueConversation GeneratePositive() 
    {
        String bumLine = GetRandomLine(bum_lines);
        String actorLine = GetRandomLine(actor_positive);
        return new DialogueConversation().Add(bumLine, SpriteUtil.GetHoboMugshot()).Add(actorLine);
        
    }

    public static DialogueConversation GenerateNeutral()
    {
        String bumLine = GetRandomLine(bum_lines);
        String actorLine = GetRandomLine(actor_neutral);
        return new DialogueConversation().Add(bumLine, SpriteUtil.GetHoboMugshot()).Add(actorLine);
    }

    public static DialogueConversation GenerateNegative()
    {
        String bumLine = GetRandomLine(bum_lines);
        String actorLine = GetRandomLine(actor_negative);
        return new DialogueConversation().Add(bumLine, SpriteUtil.GetHoboMugshot()).Add(actorLine);
    }

    public static DialogueConversation GeneratePolice0()
    {
        return new DialogueConversation().Add(GetRandomLine(actor_police0));
    }

    public static DialogueConversation GeneratePolice1()
    {
        return new DialogueConversation().Add(GetRandomLine(actor_police1));
    }

    private static String GetRandomLine(string[] array)
    {
        return array[UnityEngine.Random.Range(0, array.Length - 1)];
    }

}

