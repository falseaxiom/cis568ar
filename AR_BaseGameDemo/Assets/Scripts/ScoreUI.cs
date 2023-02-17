using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

namespace MyFirstARGame
{
    public class ScoreUI : MonoBehaviourPun
    {
        private TextMeshProUGUI[] scoreText = new TextMeshProUGUI[2];

        [SerializeField]
        private int playerId;

        private bool set = false;

        void setUp()
        {
            playerId = PhotonNetwork.LocalPlayer.ActorNumber - 2;
            scoreText[0] = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
            scoreText[1] = GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>();
        }

        // Start is called before the first frame update
        void Start()
        {
            // nothing?
        }

        // Update is called once per frame
        void Update()
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.Log("not in room");
                return;
            }
            //if (Global.singleton == null)
            //{
            //    Debug.Log("null singleton");
            //    return;
            //}

            if (!set)
            {
                setUp();
                set = true;
            }
        }

        public void OnGUI()
        {
            //GameObject global = GameObject.Find("Global");
            //Global g = global.GetComponent<Global>();
            for (int i = 0; i < 2; i++)
            {
                if (i == playerId) scoreText[i].text = "Your Score: " + Global.singleton.scores[i]; //g.scores[i];
                else scoreText[i].text = playerId.ToString() + "Player " + (i + 1) + " Score: " + Global.singleton.scores[i]; //g.scores[i];
            }
        }
    }
}
