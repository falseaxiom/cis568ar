using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyFirstARGame
{
    public class Global : MonoBehaviourPun
    {
        public float timer;
        public bool playersReady;

<<<<<<< Updated upstream:AR_BaseGameDemo/Assets/Global.cs
        public int score1;
        public int score2;
=======
        public int[] scores = new int[2];
>>>>>>> Stashed changes:AR_BaseGameDemo/Assets/Scripts/Global.cs

        public bool bigBullets;

        public int maxScore = 100; // for now

        //public bool 

        // Start is called before the first frame update
        void Start()
        {
            timer = 10.0f; // game lasts 15 seconds
            playersReady = false;
<<<<<<< Updated upstream:AR_BaseGameDemo/Assets/Global.cs

            score1 = 0;
            score2 = 0;
=======
            bigBullets = false;

            GetComponent<PhotonView>().Synchronization = ViewSynchronization.UnreliableOnChange;
>>>>>>> Stashed changes:AR_BaseGameDemo/Assets/Scripts/Global.cs
        }

        // Update is called once per frame
        void Update()
        {
            // IF BOTH PLAYERS ARE READY, START THE CLOCK *************
            //if (playersReady)
            //{
                //timer -= Time.deltaTime;

            var playerId = PhotonNetwork.LocalPlayer.ActorNumber - 2;
            for (int i=0; i < scores.Length; i++)
            {
                if (scores[i] >= maxScore)
                {
<<<<<<< Updated upstream:AR_BaseGameDemo/Assets/Global.cs
                    Debug.Log("Ran out of time - tally scores + determine win/loss players"); // TO-DO
                    // end the game, display scores
                    Time.timeScale = 0; 
=======
                    // game end

                    TextMeshProUGUI winlose = GameObject.Find("WinLose").GetComponent<TextMeshProUGUI>();
                    if (i == playerId)  winlose.text = "WINNER :)";
                    else                winlose.text = "LOSER :(";

                    TextMeshProUGUI p1score = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
                    TextMeshProUGUI p2score = GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>();
>>>>>>> Stashed changes:AR_BaseGameDemo/Assets/Scripts/Global.cs
                }
            }
            //}

        }
<<<<<<< Updated upstream:AR_BaseGameDemo/Assets/Global.cs
=======

        void InitSingleton()
        {
            singleton = this;
        }

        public void restart()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            GetComponent<PhotonView>().RPC("restartGame", RpcTarget.All);
        }

        [PunRPC]
        void restartGame()
        {
            //PhotonNetwork.LoadLevel(PhotonNetwork.CurrentRoom.Name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
>>>>>>> Stashed changes:AR_BaseGameDemo/Assets/Scripts/Global.cs
    }
}
