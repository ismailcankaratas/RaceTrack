using Photon.Realtime;
using RacingCarMultiPlayer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingCarMultiPlayer
{
    public class LoginCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject loginCanvas, loadingCanvas;

        private void Awake()
        {
            ActivateLogin();
            //Launcer.OnAttemptToConnect += ActiveLoading;
            //Launcer.OnDisconnect += ActivateLogin;
        }

        private void OnDestroy()
        {
            //Launcer.OnAttemptToConnect -= ActivateLogin;
            //Launcer.OnDisconnect -= ActiveLoading;
        }

        private void ActiveLoading()
        {
            loginCanvas.gameObject.SetActive(false);
            loadingCanvas.gameObject.SetActive(true);
        }

        private void ActivateLogin()
        {
            loginCanvas.gameObject.SetActive(true);
            loadingCanvas.gameObject.SetActive(false);
        }
    }
}
