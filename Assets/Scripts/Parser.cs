using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Notification
{
    public string name;
    public string exercise;
    public string localization;
    public string bones;

    public Notification(string name, string exercise, string localization, string bones)
    {
        this.name = name.Trim();
        this.exercise = exercise.Trim();
        this.localization = localization.Trim();
        this.bones = bones.Trim();
    }
}

public static class Parser
{
    public static bool IsNotification(string rawMsg)
    {
        string[] tokens = rawMsg.Split(';');
        if (tokens[0].Trim() == ">")
        {
            return true;
        }
        return false;
    }

    public static Notification CreateNotification(string rawMsg)
    {
        string[] tokens = rawMsg.Split(';');

        Notification message = new Notification(tokens[1], tokens[2], tokens[3], tokens[4]);

        return message;
    }
}
