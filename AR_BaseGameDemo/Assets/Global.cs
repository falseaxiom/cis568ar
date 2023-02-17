using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class Global : MonoBehaviour
    {
        public float timer;
        public bool playersReady;

        public int score1;
        public int score2;

        //public bool 

        // Start is called before the first frame update
        void Start()
        {
            timer = 10.0f; // game lasts 15 seconds
            playersReady = false;

            score1 = 0;
            score2 = 0;
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
                    Time.timeScale = 0; 
                }
            }

        }
    }
}
