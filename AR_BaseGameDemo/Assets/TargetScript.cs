using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class TargetScript : MonoBehaviour
    {

        public int pointValue;

        // Start is called before the first frame update
        void Start()
        {
            pointValue = pointValue + 0;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        [PunRPC]
        public void Die()
        {
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Debug.Log("ProjectileBehavior: Hit target");
<<<<<<< Updated upstream:AR_BaseGameDemo/Assets/TargetScript.cs
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
=======

                PhotonNetwork.Destroy(collision.gameObject); // Destroy the bullet
                //PhotonNetwork.Destroy(this.gameObject);

                GameObject global = GameObject.Find("Global");
                //global.GetPhotonView().RPC("Die", RpcTarget.All);

                this.gameObject.GetPhotonView().TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                PhotonNetwork.Destroy(this.gameObject);
>>>>>>> Stashed changes:AR_BaseGameDemo/Assets/Scripts/TargetScript.cs
            }
        }
    }
}
