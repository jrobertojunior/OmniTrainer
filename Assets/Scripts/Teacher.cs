using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NotificationEvent : UnityEvent<Notification> { }

public class Teacher : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    public NotificationEvent OnNewNotification = new NotificationEvent();

    string oldmsg = "";
    string msg = "";

    void Start()
    {
        
    }
    void Update()
    {
        if (msg != oldmsg)
        {
            counterText.text = msg;
            oldmsg = msg;

            print(msg);

            string[] tokens = msg.Split(';');

            if (Parser.IsNotification(msg))
            {
                Notification not = Parser.CreateNotification(msg);
                print(not.name);
            }
        }
    }

    public void PrintMessage(string msg)
    {
        print("teacher received: " + msg);
    }

    public void UpdateCounterText(string msg)
    {
        this.msg = msg;
    }

    public void ButtonText()
    {
        counterText.text = "some tet";
    }
}
