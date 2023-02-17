using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Debug.Log("ProjectileBehavior: Hit target");

                //GameObject global = GameObject.Find("Global");
                //Spawner s = global.GetComponent<Spawner>();
                //s.Kill(this.gameObject);

                //NetworkLauncher.Destroy(collision.gameObject);

                PhotonNetwork.Destroy(collision.gameObject);
                //PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
