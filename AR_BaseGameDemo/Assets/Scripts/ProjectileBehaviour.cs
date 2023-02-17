namespace MyFirstARGame
{
    using UnityEngine;
    using Photon.Pun;

    /// <summary>
    /// Controls projectile behaviour. In our case it currently only changes the material of the projectile based on the player that owns it.
    /// </summary>
    public class ProjectileBehaviour : MonoBehaviourPun
    {
        [SerializeField]
        private Material[] projectileMaterials;

        public int playerId;

        //public float projectileTimer = 5.0f;

        private void Awake()
        {
            // Pick a material based on our player number so that we can distinguish between projectiles. We use the player number
            // but wrap around if we have more players than materials. This number was passed to us when the projectile was instantiated.
            // See ProjectileLauncher.cs for more details.
            var photonView = this.transform.GetComponent<PhotonView>();
            var playerId = Mathf.Max((int)photonView.InstantiationData[0], 0);
            if (this.projectileMaterials.Length > 0)
            {
                var material = this.projectileMaterials[playerId % this.projectileMaterials.Length];
                this.transform.GetComponent<Renderer>().material = material;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            playerId = Mathf.Max((int)photonView.InstantiationData[0], 0);

            if (collision.gameObject.tag == "Target")
            {
                Debug.Log("ProjectileBehavior: Hit target");

                GameObject target = collision.gameObject;
                TargetScript t = target.GetComponent<TargetScript>();

<<<<<<< Updated upstream
                GameObject global = GameObject.Find("Global");
                Global g = global.GetComponent<Global>();
=======
                GetComponent<PhotonView>().RPC("updateScore", RpcTarget.All, playerId-2, t.pointValue);
            }
            else if (collision.gameObject.tag == "Player")
            {
                Debug.Log("ProjectileBehavior: Hit player");
>>>>>>> Stashed changes

                GameObject target = collision.gameObject;
                TargetScript t = target.GetComponent<TargetScript>();

<<<<<<< Updated upstream
                if (playerId == 2)
                {
                    g.score1 += t.pointValue;
                }
                else if (playerId == 3)
                {
                    g.score2 += t.pointValue;
=======
                // remove points from other player
                if (playerId-2 == 0)      GetComponent<PhotonView>().RPC("updateScore", RpcTarget.All, 1, -3);
                else if (playerId-2 == 1) GetComponent<PhotonView>().RPC("updateScore", RpcTarget.All, 0, -3);

                // spawn resource with probability
                if (Random.Range(0.0f, 1.0f) < 0.2)
                {
                    Vector3 pos = target.transform.position - new Vector3(0.0f, 0.1f, 0.0f);
                    PhotonNetwork.Instantiate("Resource1Prefab", pos, Quaternion.identity);
>>>>>>> Stashed changes
                }
            }
            else if (collision.gameObject.tag == "Resource1")
            {
                collision.gameObject.GetPhotonView().TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                PhotonNetwork.Destroy(collision.gameObject);

                GameObject g = GameObject.Find("Main Camera");
                ProjectileLauncher pj = g.GetComponent<ProjectileLauncher>();

                if (playerId - 2 == 0) pj.p1HasBigBullet = true;
                if (playerId - 2 == 1) pj.p2HasBigBullet = true;
            }
            else if (collision.gameObject.tag == "Resource2")
            {
                collision.gameObject.GetPhotonView().TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
                PhotonNetwork.Destroy(collision.gameObject);
            }
        }

        [PunRPC]
        public void updateScore(int playerId, int points)
        {
            Global.singleton.scores[playerId] += points;
        }

        // updates the timer on the projectile - 5 secs life
        private void Update()
        {
            //projectileTimer -= Time.deltaTime;
            //if (projectileTimer <= 0)
            //{
            //    Debug.Log("timer ran out - im dead");
            //    Destroy(this.gameObject);
            //}
        }
    }
}
