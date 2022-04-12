using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
// Voidaan hakea Unityss‰ olevaan UI tekstikent‰‰n kirjoittu teksti
using UnityEngine.UI;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField lobbyName;

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;

        // Lobbyll‰ on oltava nimi, muuten tulee errori, koska ei olla tehty virheentarkistusjuttuja
        PhotonNetwork.CreateRoom(lobbyName.text, roomOptions, null);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(lobbyName.text);
    }

    // Ei tehd‰ short returnCode:lla ja string message:lla mit‰‰n
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Forest");
    }
}
