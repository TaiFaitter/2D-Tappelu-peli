using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
// K?ytet?? Photon hommia
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        // Syncronoi n?kym?t n?kym??n samanlaisiksi kaikille pelaajille
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        // Lainausmerkkeihin kirjoitetaan joko Scenen nimi tai sen indeksi
        SceneManager.LoadScene("Lobby");
    }
}
