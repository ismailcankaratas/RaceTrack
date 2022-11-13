using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using TMPro;

namespace RacingCarMultiPlayer
{
    public class Launcer : MonoBehaviourPunCallbacks
    {
        [Header("InputFieslds")]
        public TMP_InputField _roomNameInput;
        public TMP_Dropdown _roomMaxPlayers;
        [Header("Panels")]
        public GameObject[] _panelsGameObjects;

        #region UnityEvents
        private void Start()
        {
            LoginPanelActive();
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        #endregion


        #region PanelMethods

        public void LoginPanelActive()
        {
            PanelsDisable();
            _panelsGameObjects[0].SetActive(true);
        }

        public void LobbyPanelActive()
        {
            PanelsDisable();
            _panelsGameObjects[1].SetActive(true);
        }

        public void CreateRoomPanelActive()
        {
            PanelsDisable();
            _panelsGameObjects[2].SetActive(true);
        }

        public void JoinRandomRoomPanelActive()
        {
            PanelsDisable();
            _panelsGameObjects[3].SetActive(true);
        }

        public void LoadingPanelActive()
        {
            PanelsDisable();
            _panelsGameObjects[4].SetActive(true);
        }

        #endregion



        #region Public Methods

        public void PanelsDisable()
        {
            foreach (GameObject gameObject in _panelsGameObjects)
            {
                gameObject.SetActive(false);
            }
        }

        public void Connect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public void CreateRoom()
        {
            byte roomMaxPlayers;

            #region roomMaxPlayers Switch Case
            switch (_roomMaxPlayers.value)
            {
                case 0:
                    roomMaxPlayers = 2;
                    break;
                case 1:
                    roomMaxPlayers = 3;
                    break;
                case 2:
                    roomMaxPlayers = 4;
                    break;
                default:
                    roomMaxPlayers = 2;
                    break;
            }
            #endregion

            Debug.LogWarning(roomMaxPlayers);
            string roomName = _roomNameInput.text;
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = roomMaxPlayers;

            PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default, null);
        }

        public void JoinRandomOrCreateRoom()
        {
            PhotonNetwork.JoinRandomOrCreateRoom(roomName: PhotonNetwork.NickName + "'in odasý");
        }

        #endregion

#region PhotonCallbaks


        public override void OnConnectedToMaster()
        {
            Debug.Log("Server'a "+ PhotonNetwork.NickName + " adýyla baðlanýldý.");
            LobbyPanelActive();
        }
        public override void OnConnected()
        {
            base.OnConnected();
            Debug.Log("Ýnternete baðlandý.");
        }

        public override void OnCreatedRoom()
        {
            Debug.Log(PhotonNetwork.CurrentRoom.Name + " adýyla oda oluþturuldu.");
        }
        public override void OnJoinedRoom()
        {
            Debug.Log(PhotonNetwork.CurrentRoom.Name + " adýyla odaya giriþ yapýldý.");
            PhotonNetwork.LoadLevel("RaceTrack");
        }
#endregion
    }
}
