using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RacingCarMultiPlayer
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public GameObject _playerPrefab;

        [Header("Player Rising Cordinats")]
        public float minX;
        public float maxX;
        public float minZ;
        public float maxZ;

        [Header("GameBoard")]
        [SerializeField] private TextMeshProUGUI roomName;
        [SerializeField] private TextMeshProUGUI onlinePlayers;

        private double[] carPositionsX = { -12.51, -15.6, -12.54, -15.65 };
        private double[] carPositionsY = { 86.8, 82.5, 77.87, 73.48 };
            

        private void Start()
        {
            roomName.text = PhotonNetwork.CurrentRoom.Name;
            if (PhotonNetwork.IsConnectedAndReady)
            {
                Vector3 randomPosition = new Vector3((float)carPositionsX[PhotonNetwork.CurrentRoom.PlayerCount - 1], 0, (float)carPositionsY[PhotonNetwork.CurrentRoom.PlayerCount - 1]);
                PhotonNetwork.Instantiate(_playerPrefab.name, randomPosition, Quaternion.identity, 0, null);
            }
        }

        #region Photon Callbacks

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnJoinedRoom()
        {
            onlinePlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " Aktif";
        }

        #endregion


        #region Public Methods
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion

        #region Private Methods


        #endregion

        #region PhotonCallbacks


        #endregion
    }
}