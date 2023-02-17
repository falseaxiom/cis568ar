using System.Collections;
using System.Collections.Generic;
using MyFirstARGame;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.Samples
//namespace MyFirstARGame
{
    public class RestartButton : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        GameObject m_RestartButton;

        //Global global;

        public GameObject restartButton
        {
            get => m_RestartButton;
            set => m_RestartButton = value;
        }

        void Start()
        {
            m_RestartButton.SetActive(true);
        }

        void Update()
        {
            //if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
            //    RestartButtonPressed();
        }

        public void RestartButtonPressed()
        {
            // RPC to restart whole game
            //GetComponent<PhotonView>().RPC("restartGame", RpcTarget.All);

            //global.
            Global.singleton.restart();

            //PhotonNetwork.AutomaticallySyncScene = true;
            //GetComponent<PhotonView>().RPC("restartGame", RpcTarget.MasterClient);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //[PunRPC]
        //void restartGame()
        //{
        //    if (PhotonNetwork.IsMasterClient) PhotonNetwork.LoadLevel(PhotonNetwork.CurrentRoom.Name);
        //}
    }
}
