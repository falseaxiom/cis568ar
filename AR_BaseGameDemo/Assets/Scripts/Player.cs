using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace MyFirstARGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private int playerId;

        private bool set = false;

        // Start is called before the first frame update
        void Start()
        {
            playerId = PhotonNetwork.LocalPlayer.ActorNumber - 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (!PhotonNetwork.InRoom)
            {
                Debug.Log("not in room");
                return;
            }

            if (!set)
            {
                playerId = PhotonNetwork.LocalPlayer.ActorNumber - 2;
                set = true;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            //if (collision.gameObject.tag == "Bullet")
            //{
            //    Debug.Log("Hit player");

            //    if (playerId == 0)      Global.singleton.scores[1] -= 3;
            //    else if (playerId == 1) Global.singleton.scores[0] -= 3;

            //    PhotonNetwork.Destroy(collision.gameObject);// Destroy the bullet

            //    // Hitting player drops resource
            //    //var resource = PhotonNetwork.Instantiate("Resource1", spawnPosition, Quaternion.identity);
            //}
        }
    }
}
