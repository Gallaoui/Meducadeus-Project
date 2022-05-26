using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Database;
public class ChatSystemManager : MonoBehaviour
{
    private FirebaseDatabase reference;


    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if(task.Exception != null) { print($"Failed to initialize Database {task.Exception}"); return; }
            
        });
        reference = FirebaseDatabase.DefaultInstance;
    }


    public void SendMessage(Message msg, Action callback, string channelName)
    {
        var msgJSON = StringSerializationAPI.Serialize(typeof(Message), msg);

        reference.GetReference(channelName).Push().SetRawJsonValueAsync(msgJSON).ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted) print("failed msg");
            else callback();
        });
    }

    public void getMessages(Action<Message> callback, string channelName)
    {
        void CuLis(object o, ChildChangedEventArgs args)
        {
            if (args.DatabaseError != null) print("getmessages failed");
            else callback(StringSerializationAPI.Deserialize(typeof(Message), args.Snapshot.GetRawJsonValue()) as Message);
        }

        reference.GetReference(channelName).ChildAdded += CuLis;
    }
}
