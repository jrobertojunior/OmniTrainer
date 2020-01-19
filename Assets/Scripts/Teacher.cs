using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class NotificationEvent : UnityEvent<Notification> { }

[System.Serializable]
public class NotificationAlert : UnityEvent { }



public class Teacher : MonoBehaviour
{
    public NotificationAlert OnNewNotification = new NotificationAlert();

    string oldmsg = "";
    string msg = "";

    bool oneError = true;

    void Start()
    {
        
    }
    void Update()
    {
        if (msg != oldmsg)
        {
            oldmsg = msg;

            print(msg);

            string[] tokens = msg.Split(';');

            if (Parser.IsNotification(msg) && oneError == true)
            {
                // error msg
                //Notification not = Parser.CreateNotification(msg);
                OnNewNotification.Invoke();

                oneError = false;
            }
        }
    }

    public void PrintMessage(string msg)
    {
        print("teacher received: " + msg);
    }

    public void ReceivedMessage(string msg)
    {
        this.msg = msg;
    }
}
