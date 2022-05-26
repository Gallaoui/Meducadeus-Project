using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
public class ConnectToServer : MonoBehaviourPunCallbacks
{

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected To " + PhotonNetwork.CloudRegion + " Server");
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public static void CreateAndJoinRoom()
    {
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 20 };

        PhotonNetwork.JoinOrCreateRoom("Room", roomOps, TypedLobby.Default);
    }

    public void Username()
    {
        PhotonNetwork.NickName = FirebaseConnection.instance.getUsername();
    }

    public override void OnJoinedRoom()
    {
        // PhotonNetwork.LoadLevel(1);

        SceneManager.LoadScene(1);
    }
}
