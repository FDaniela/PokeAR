using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;

public class GameConnection : MonoBehaviourPunCallbacks
{
    // private ExitGames.Client.Photon.Hashtable _playerProperties = new ExitGames.Client.Photon.Hashtable();

    public Text chatLog;

    //public Player player {get; private set;}

    //--------------------------------------------------------
    void Awake()
    {
        chatLog.text = "Conectando no servidor...";
        PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.ConnectUsingSettings();
    }

    //--------------------------------------------------------
    public override void OnConnectedToMaster()
    {
        chatLog.text += "\nConectado no servidor!";
        if (PhotonNetwork.InLobby == false)
        {
            chatLog.text += "\nEntrando no Lobby...";
            PhotonNetwork.JoinLobby();
        }
    }

    //--------------------------------------------------------
    public override void OnJoinedLobby()
    {
        chatLog.text += "\nEntrou no Lobby!";
        PhotonNetwork.JoinRoom("PokeAR");
        chatLog.text += "\nEntrando na sala PokeAR...";
        //GameController.InicializaBaralho();
    }

    //--------------------------------------------------------
    public override void OnJoinRoomFailed(short returnCode, string message)
    {

        if (returnCode == ErrorCode.GameDoesNotExist)
        {
            RoomOptions room = new RoomOptions { MaxPlayers = 2 };

            Hashtable RoomCustomProps = new Hashtable();
            RoomCustomProps.Add("P1Name", PhotonNetwork.LocalPlayer.NickName);
            RoomCustomProps.Add("P2Name", "null");
            RoomCustomProps.Add("P1Money", 900);
            RoomCustomProps.Add("P2Money", 950);
            RoomCustomProps.Add("P1Status", "null");
            RoomCustomProps.Add("P2Status", "null");
            RoomCustomProps.Add("Raise", 0);
            RoomCustomProps.Add("Turn", true);
            RoomCustomProps.Add("P1Bet", 100);
            RoomCustomProps.Add("P2Bet", 50);
            RoomCustomProps.Add("Pot", 150);

            room.CustomRoomProperties = RoomCustomProps;

            PhotonNetwork.CreateRoom("PokeAR", room, null);
            chatLog.text += "\nCriando sala PokeAR!";
        }



    }

    //--------------------------------------------------------
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        chatLog.text += "\nPlayer entrou na sala: " + newPlayer.NickName;
    }



    //--------------------------------------------------------
    public override void OnJoinedRoom()
    {
        chatLog.text += "\nVocê entrou na sala: PokeAR, como: " + PhotonNetwork.LocalPlayer.NickName;
        //Instantiate do Photon carrega um prefab do Resources
        // PhotonNetwork.Instantiate("Player",new Vector3(0,0,0), Quaternion.identity, 0);
        // SetCustomProperties();


    }




}
