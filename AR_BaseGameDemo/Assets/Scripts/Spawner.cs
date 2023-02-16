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

        public float spawnSmallRate = 15.0f;
        public float spawnMediumRate = 7.0f;
        public float spawnLargeRate = 3.0f;
    
        // Start is called before the first frame update
        void Start()
        {

            //call
            NetworkLauncher.Singleton.JoinedRoom += this.SpawnSomething;


            NetworkLauncher.Singleton.JoinedRoom += this.RepeatSpawnSmall;
            NetworkLauncher.Singleton.JoinedRoom += this.RepeatSpawnMedium;
            NetworkLauncher.Singleton.JoinedRoom += this.RepeatSpawnLarge;


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
            Debug.Log("joined room - spawned med target");
            //GameObject md_target = PhotonNetwork.Instantiate("MediumTargetPrefab", spawnPosition, Quaternion.identity) as GameObject;
            //md_target.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f); // scale the prefab

        }

        private void RepeatSpawnSmall(NetworkLauncher sender)
        {
            InvokeRepeating(nameof(SpawnSmallTarget), this.spawnSmallRate, this.spawnSmallRate);
        }

        private void RepeatSpawnMedium(NetworkLauncher sender)
        {
            InvokeRepeating(nameof(SpawnMediumTarget), this.spawnMediumRate, this.spawnMediumRate);
        }

        private void RepeatSpawnLarge(NetworkLauncher sender)
        {
            InvokeRepeating(nameof(SpawnLargeTarget), this.spawnLargeRate, this.spawnLargeRate);
        }

        private void SpawnSmallTarget()
        {
            Debug.Log("Spawned a small cube!");

            // TO-DO: pick random position between min & max bounds - ASSUMING WORLD COORDINATES
            float pos_x = Random.Range(-bounds, bounds);
            float pos_y = Random.Range(0.5f, bounds);
            float pos_z = Random.Range(-bounds, bounds);

            Vector3 spawnPosition = new Vector3(pos_x, pos_y, pos_z);

            // spawn small target
            GameObject sm_target = PhotonNetwork.Instantiate("SmallTargetPrefab", spawnPosition, Quaternion.identity) as GameObject;
            sm_target.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f); // scale the prefab
        }

        private void SpawnMediumTarget()
        {
            Debug.Log("Spawned a medium cube!");

            // TO-DO: pick random position between min & max bounds - ASSUMING WORLD COORDINATES
            float pos_x = Random.Range(-bounds, bounds);
            float pos_y = Random.Range(0.5f, bounds);
            float pos_z = Random.Range(-bounds, bounds);

            Vector3 spawnPosition = new Vector3(pos_x, pos_y, pos_z);

            // spawn small target
            GameObject md_target = PhotonNetwork.Instantiate("MediumTargetPrefab", spawnPosition, Quaternion.identity) as GameObject;
            md_target.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // scale the prefab
        }

        private void SpawnLargeTarget()
        {
            Debug.Log("Spawned a large cube!");

            // TO-DO: pick random position between min & max bounds - ASSUMING WORLD COORDINATES
            float pos_x = Random.Range(-bounds, bounds);
            float pos_y = Random.Range(0.5f, bounds);
            float pos_z = Random.Range(-bounds, bounds);

            Vector3 spawnPosition = new Vector3(pos_x, pos_y, pos_z);

            // spawn small target
            GameObject lg_target = PhotonNetwork.Instantiate("LargeTargetPrefab", spawnPosition, Quaternion.identity) as GameObject;
            lg_target.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f); // scale the prefab
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
