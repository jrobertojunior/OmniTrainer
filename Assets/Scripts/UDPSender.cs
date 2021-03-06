﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDPSender : MonoBehaviour
{
    private UDPSocket c;

    int counter = 0;

    [SerializeField]
    private int port = 27002;

    [SerializeField]
    private string Ip = "127.0.0.1";

    void Start()
    {
        //s = new UDPSocket();
        //s.Server("127.0.0.1", 27002);

        c = new UDPSocket();
        c.Client(Ip, port);
        c.Send("initial msg");

        //s.OnNewMessage = new MessageEvent();
        //s.OnNewMessage.AddListener(NewMessage);

        //OnNewMessageEvent = new MessageEvent();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            var msg = "counter " + counter.ToString();
            c.Send(msg);
            print("sender: " + msg);
            counter += 1;
        }
    }
}
