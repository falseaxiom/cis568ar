using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class Global : MonoBehaviour
    {
        public static Global singleton = null;

        public float timer;
        public bool playersReady;

        public int score1;
        public int score2;
        public int[] scores = new int[2];

        //public bool 

        // Start is called before the first frame update
        void Start()
        {
            InitSingleton();

            timer = 10.0f; // game lasts 15 seconds
            playersReady = false;
        }

        // Update is called once per frame
        void Update()
        {
            // IF BOTH PLAYERS ARE READY, START THE CLOCK *************
            if (playersReady)
            {
                timer -= Time.deltaTime;

                if (timer < 0.0f)
                {
                    Debug.Log("Ran out of time - tally scores + determine win/loss players"); // TO-DO
                    // end the game, display scores
                    //Time.timeScale = 0; 
                }
            }

        }

        void InitSingleton()
        {
            singleton = this;
        }
    }
}
