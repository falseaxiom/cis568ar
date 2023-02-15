using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace MyFirstARGame
{
    public class Spawner : MonoBehaviour
    {
        private float bounds = 2f;
    
        // Start is called before the first frame update
        void Start()
        {
            NetworkLauncher.Singleton.JoinedRoom += this.SpawnSomething;
        }
        
        private void SpawnSomething(NetworkLauncher sender)
        {
//            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//            cube.transform.position = Vector3.zero;
//            cube.transform.localScale = new Vector3(0.05f,0.05f,0.05f);

            // TO-DO: pick random position between min & max bounds - ASSUMING WORLD COORDINATES
            float pos_x = Random.Range(-bounds, bounds);
            float pos_y = Random.Range(0.5f, bounds);
            float pos_z = Random.Range(-bounds, bounds);

            Vector3 spawnPosition = new Vector3(pos_x, pos_y, pos_z);

            // spawn small target
            // this.projectilePrefab.name

            GameObject sm_target = PhotonNetwork.Instantiate("SmallTargetPrefab", spawnPosition, Quaternion.identity) as GameObject;
            sm_target.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
