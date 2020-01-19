using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RegisterHostMessage : MessageBase
{
    public string gameName;
    public string comment;
    public bool passwordProtected;
}

public class UnityNetwork : MonoBehaviour
{
    public string ClientIp = "127.0.0.1";
    public int port = 4444;

    NetworkClient myClient;
    public const short RegisterHostMsgId = 888;

    // Start is called before the first frame update
    void Start()
    {
        SetupServer();
        SetupClient();
    }

    // Update is called once per frame
    void Update()
    {
        RegisterHostMessage msg = new RegisterHostMessage();
        msg.gameName = name;
        msg.comment = "test";
        msg.passwordProtected = false;

        myClient.Send(RegisterHostMsgId, msg);
    }

    public void SetupServer()
    {
        NetworkServer.Listen(port);
    }

    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect(ClientIp, port);
        //isAtStartup = false;
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server " + myClient.serverIp);
    }

}
