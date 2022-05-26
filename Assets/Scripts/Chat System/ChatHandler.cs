using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatHandler : MonoBehaviour
{
    public Text texter;
    public InputField input;
    public ChatSystemManager db;

    private void Start()
    {
       // db.getMessages(im );
    }

    public void sndmsg() => db.SendMessage(new Message("tony", input.text), () => print("message sent"), "channel");

    private void im(Message msg)
    {
        texter.text += $"{msg.user} : {msg.message}";
    }
}
